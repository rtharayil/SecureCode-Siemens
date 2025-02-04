#include <iostream>
#include <crow.h>

int main() {
    crow::SimpleApp app;
    int* order_price = nullptr; // Create the pointer

    CROW_ROUTE(app, "/order/start")
    ([&order_price]() -> std::string {
        order_price = new int(25); // Allocate memory and assign the location to the pointer
        return "Order started for $" + std::to_string(*order_price);
    });

    CROW_ROUTE(app, "/order/confirm")
    ([&order_price]() -> std::string {
        // proccess_ticket(order_price)

        return "The price $" + std::to_string(*order_price) + " was noted on your ticket and will be charged upon entry";  // View the memory data at the pointer address
    });

    CROW_ROUTE(app, "/order/cancel")
    ([&order_price]() -> std::string {
        delete order_price; // Release the memory
        return "Order canceled";
    });