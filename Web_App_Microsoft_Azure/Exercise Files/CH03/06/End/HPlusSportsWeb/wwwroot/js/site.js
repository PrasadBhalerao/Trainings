// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addToCart(id, name) {
    var items = getCartItems();

    if (!items) {
        items = [];
    }

    var prodSize = $("input[name='size']").val();
    items.push({
        "id": id,
        "name": name,
        "quantity": 1,
        "size": prodSize
    });
    localStorage.setItem("cartItems", JSON.stringify(items));
}

function getCartItems() {
    var items = localStorage.getItem("cartItems");
    return JSON.parse(items);

}

function clearCart() {
    localStorage.removeItem("cartItems");
}
