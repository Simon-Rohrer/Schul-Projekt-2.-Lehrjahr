const addToOrder = document.getElementById("addToOrder");
const editOrder = document.getElementById("editOrder");
const deleteOrder = document.getElementById("deleteOrder");
const closeWindow = document.getElementById("closeWindow");
const addFood = document.getElementById("addFood");
const addFoodWindow = document.getElementById("addFoodWindow");

addFood.addEventListener("click", function() {
    const url = 'http://localhost:8080/add-order.html';
    const fensterName = '_blank';
    const eigenschaften = 'width=600,height=400,popup=yes';

    addFoodWindow.style.display = "block";
    window.open(url, fensterName, eigenschaften);
});

addToOrder.addEventListener("click", function() {
    
})

editOrder.addEventListener("click", function() {
    addFoodWindow.style.display = "block";
})

deleteOrder.addEventListener("click", function() {

})

closeWindow.addEventListener("click", function() {
    addFoodWindow.style.display = "none";
})