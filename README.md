🛒 Shopping Cart System (Enhanced)

📌 System Description
    This project is a console-based Shopping Cart System built using C#. It applies object-oriented programming principles such as classes, objects, methods, and arrays to simulate a basic retail shopping experience.
    The system allows users to browse products, manage a shopping cart, validate stock availability, and process checkout transactions. It is progressively enhanced from a basic cart system (Part 1) into a more advanced system with full cart management, payment validation, receipt generation, and order tracking (Part 2).

>> Features

Part 1: Basic Shopping Cart System
•	Implements a Product class containing product details such as Id, Name, Price, and RemainingStock. 
•	Displays a product menu using arrays and looping structures. 
•	Allows users to select products and specify quantity for purchase. 
•	Validates user input including: 
o	Non-numeric inputs using int.TryParse() 
o	Invalid product selection 
o	Invalid quantity input 
•	Enforces stock control: 
o	Prevents purchasing beyond available stock 
o	Handles out-of-stock products appropriately 
•	Manages cart operations: 
o	Adds selected products to the cart 
o	Updates quantity instead of creating duplicate entries 
o	Prevents cart overflow when using fixed-size arrays 
•	Automatically deducts purchased quantity from product stock. 
•	Generates a receipt upon checkout including: 
o	Grand total 
o	Applied discount (10% for purchases ≥ 5000) 
o	Final total after discount 
•	Displays updated stock after checkout completion. 

Part 2: Enhanced Shopping Cart System
•	Introduces a Cart Management Menu that allows users to: 
o	View cart / bag contents 
o	Update item / product quantities 
o	Remove items from cart / bag
o	Clear the entire cart / bag
o	Proceed to checkout 
•	Adds Product Search functionality to locate items by name. 
•	Implements Product Categorization, allowing products to be grouped and filtered by category. 
•	Enhances the Checkout System with: 
o	Payment input validation (numeric and sufficient amount required) 
o	Automatic change computation 
•	Upgrades the Receipt System, now including: 
o	Unique receipt number 
o	Date and time of transaction 
o	List of purchased items 
o	Discount applied (if any) 
o	Final total 
o	Payment received and change returned 
•	Adds Low Stock Alert System: 
o	Displays products with remaining stock of 5 or below after checkout 
•	Introduces Order History Tracking: 
o	Stores completed transactions during program execution 
o	Allows users to view past orders within the session 
•	Implements Strict Input Validation across all menus and confirmation prompts to ensure correct user input handling. 

🤖 AI Usage Declaration

•	Which Part I used AI for 
// In understanding instructions in-depthly, Especially the AI Usage and Verbose Flowchart. 
// Input Validation using .TryParse.
// Part 2 Quiz instructions / requirements.

•	Why I used AI
// (Prompt using Chatgpt) "i mean, don't tell me what to code, i just want you to explain it to me. 'cause i slightly don't get the instructions "AI usage explaination" and "Verbose Flowchart" 
// (Prompt using Gemini) "can you explain me how to use this .TryParse on simple code or logic?"
// (Prompt using Chatgpt) “Please explain this part 2 quiz carefully (don’t code it) for you to clarify to me each part and to avoid misinformation/wrong doings. Do the explaintions from top to bottom.

•	Improvements 
// The requirements are clear to me and misunderstandings have been avoided. 
// Improve by using int.TryParse instead of just int.Parse.
// I’m enlighted and know what to do first and clarified for the features each part.


