const foodTableBody = document.getElementById("foodTableBody");
const orderTableBody = document.getElementById("orderTableBody");
const addFoodWindow = document.getElementById("addFoodWindow");
const addForm = document.getElementById("addForm");
const editFoodWindow = document.getElementById("editFoodWindow");
const editForm = document.getElementById("editForm");
const deleteFoodWindow = document.getElementById("deleteFoodWindow");

const API = "http://localhost:5000/api/essen";
const API_BESTELLUNG = "http://localhost:5000/api/bestellung";

let gerichte = [];      // alle Gerichte, die gerade in der Tabelle stehen
let aktuelleId = 0;     // Gericht, das gerade bearbeitet oder gelöscht wird
let bestellung = [];    // Gerichte in der Bestellübersicht: { id, name, preis, menge }

document.getElementById("addFood").addEventListener("click", function() {
    addFoodWindow.style.display = "block";
});
document.getElementById("closeAddWindow").addEventListener("click", function() {
    addFoodWindow.style.display = "none";
});

document.getElementById("closeEditWindow").addEventListener("click", function() {
    editFoodWindow.style.display = "none";
});

document.getElementById("deleteFoodNo").addEventListener("click", function() {
    deleteFoodWindow.style.display = "none";
});

addForm.addEventListener("submit", async function(event) {
    await fetch(API, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            name: document.getElementById("addMeal").value,
            preis: Number(document.getElementById("addPrice").value),
            vegetarisch: document.getElementById("addVegetable").checked
        })
    });
    addFoodWindow.style.display = "none";
    addForm.reset();
    loadFoodList();
});

function openEdit(id) {
    const gericht = gerichte.find(g => g.id === id);
    aktuelleId = id;
    document.getElementById("editMeal").value = gericht.name;
    document.getElementById("editPrice").value = gericht.preis;
    document.getElementById("editVegetable").checked = gericht.vegetarisch;
    editFoodWindow.style.display = "block";
}

editForm.addEventListener("submit", async function(event) {
    event.preventDefault();
    await fetch(API + "/" + aktuelleId, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            name: document.getElementById("editMeal").value,
            preis: Number(document.getElementById("editPrice").value),
            vegetarisch: document.getElementById("editVegetable").checked
        })
    });
    editFoodWindow.style.display = "none";
    loadFoodList();
});

function openDelete(id) {
    aktuelleId = id;
    deleteFoodWindow.style.display = "block";
}

document.getElementById("deleteFoodYes").addEventListener("click", async function() {
    await fetch(API + "/" + aktuelleId, { method: "DELETE" });
    bestellung = bestellung.filter(b => b.id !== aktuelleId);
    showOrder();
    deleteFoodWindow.style.display = "none";
    loadFoodList();
});

// Gericht zur Bestellung hinzufügen (gleiches Gericht: Menge + 1)
function addToOrder(id) {
    const eintrag = bestellung.find(b => b.id === id);
    if (eintrag) {
        eintrag.menge++;
    } else {
        const gericht = gerichte.find(g => g.id === id);
        bestellung.push({ id: id, name: gericht.name, preis: gericht.preis, menge: 1 });
    }
    showOrder();
}

// Bestellübersicht anzeigen
function showOrder() {
    orderTableBody.innerHTML = "";
    bestellung.forEach(b => {
        const row = document.createElement("tr");
        row.innerHTML = `
            <td>${b.menge}</td>
            <td>${b.name}</td>
            <td>${b.preis}€</td>
            <td>${(b.preis * b.menge).toFixed(2)}€</td>
        `;
        orderTableBody.appendChild(row);
    });
}

// Bestellung abschicken (POST)
document.getElementById("placeOrder").addEventListener("click", async function() {
    if (bestellung.length === 0) return;
    const response = await fetch(API_BESTELLUNG, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(bestellung.map(b => ({ speiseId: b.id, menge: b.menge })))
    });
    if (response.ok) {
        bestellung = [];
        showOrder();
    }
});

// Essen Laden
async function loadFoodList() {
    try {
        const response = await fetch(API);
        gerichte = await response.json();

        foodTableBody.innerHTML = "";

        gerichte.forEach((gericht, index) => {
            const row = document.createElement("tr");

            row.innerHTML = `
                <td>${index + 1}</td>
                <td>${gericht.name}</td>
                <td>${gericht.preis}€</td>
                <td>${gericht.vegetarisch ? "Ja" : "Nein"}</td>
                <td>
                    <button type="button" onclick="addToOrder(${gericht.id})">Add to Order</button>
                    <button type="button" onclick="openEdit(${gericht.id})">Edit</button>
                    <button type="button" onclick="openDelete(${gericht.id})">Delete</button>
                </td>
            `;

            foodTableBody.appendChild(row);
        });
    } catch (error) {
        console.error("Fehler:", error);
    }
}
loadFoodList();
