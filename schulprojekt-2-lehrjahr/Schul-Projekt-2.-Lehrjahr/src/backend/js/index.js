const addToOrder = document.getElementById("addToOrder");
const editFood = document.getElementById("editFood");

const deleteFoodWindow = document.getElementById("deleteFoodWindow");
const closeDeleteFoodWindow = document.getElementById("deleteFoodNo");

const addFood = document.getElementById("addFood");
const addFoodWindow = document.getElementById("addFoodWindow");
const closeAddWindow = document.getElementById("closeAddWindow");

const editFoodWindow = document.getElementById("editFoodWindow");
const closeEditWindow = document.getElementById("closeEditWindow");

const foodTableBody = document.getElementById("foodTableBody");

// Essen hinzufügen öffnen
addFood.addEventListener("click", function() {
    addFoodWindow.style.display = "block";
});

// Essen hinzufügen schließen
closeAddWindow.addEventListener("click", function() {
    addFoodWindow.style.display = "none";
});

// Essen bearbeiten öffnen
editFood.addEventListener("click", function() {
    editFoodWindow.style.display = "block";
});

// Essen bearbeiten schließen
closeEditWindow.addEventListener("click", function() {
    editFoodWindow.style.display = "none";
});

// Essen löschen öffnen
deleteFood.addEventListener("click", function() {
    deleteFoodWindow.style.display = "block";
});

// Essen löschen schließen
closeDeleteFoodWindow.addEventListener("click", function() {
    deleteFoodWindow.style.display = "none";
});


// Essen Laden
async function loadFoodList() {
    try {
        const response = await fetch("http://localhost:5000/api/essen");
        const gerichte = await response.json();

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