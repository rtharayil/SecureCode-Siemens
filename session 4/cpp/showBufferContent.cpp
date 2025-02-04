#include <iostream>
#include <cstring>

void showBufferContent(const char* input) {
    char buffer[10];
    strcpy(buffer, input);  
    std::cout << "Buffer content: " << buffer << std::endl;
}

int main() {
    char input[20];
    std::cout << "Enter input: ";
    std::cin >> input;
    showBufferContent(input);
    return 0;
}
