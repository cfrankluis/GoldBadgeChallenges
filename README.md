# Challenge 1: Cafe
## This App enables a user to:
- Add items to a menu
- Delete items from the menu
- See all menu items and their properties

## Adding items to the menu
---
When adding items to the menu, the user will ber prompted to provide the following properties of a menu item:
- Meal Number (ID)
- Name
- Description
- A list of ingredients   
- Price in $

When providing a list of ingredents, each ingredient must be separated with a comma as shown below:
> i.e. Cabbage, Lettuce, Tomato, Swiss Cheese, Bacon, Sliced Peppers, etc.

<br>

## Deleting items from the menu
---
When deleting items from the menu, the user will be shown a list cotiaining the name of the item and its associated ID. The user will then be asked to enter the ID number of the item that needs to be deleted.

## Showing all items in the menu
---
Each item from the menu will be shown in the following format
```
ID Name Price
Description
Ingredients
```
# Challenge 2: Claims
## This App enables a user to:
- See all claims
- Take care of next claim
- Enter a new claim

## Entering a new claim
---
When entering a new claim, the user will be prompted to enter the following properties of a claim:
- Claim ID
- Claim Type (Car, Home, Theft)
- Description
- Cost of Damage($)
- Date of Incident
- Date of Claim
- Claim validity

Once the following properties are provided, a claim would be created and stored in a queue

## Take Care of the next claim
---
When taking care of a claim, the user will be shown the next claim asked whether to take care of the claim or not. If the user chooses to take care of the claim, then it would be removed from the queue. If not, the user will return to the main menu.

## Showing all claims
---
The claims will be shown in the following format:
```
ClaimID  Type    DateOfAccident  DateOfClaim   IsValid   Amount      Description
1	 Car	   4/25/18	       4/27/18	     true      $400.00     Car accident on 465.
2	 Home    4/11/18	       4/12/18	     true      $4000.00    House fire in kitchen.
3	 Theft   4/27/18	       6/01/18	     false     $4.00       Stolen pancakes.	
```

# Challenge 3: Badges
## This App enables the user to:
- Create a new badge
- Update doors on an existing badge
- Delete all doors from an existing badge
- Show a list with all badge numbers and door access

## Creating a new badge
---
When creating a new badge, the user will be prompted to provide the following properties:
- Badge ID
- Badge Name
- A list of door names it can access

When providing a list of door names, each door name must be separated by a comma as shown below:
>i.e.  A1,A2,B1,B2,C3,C4,D7,E8

Once the following properties have been provided, a badge with the provided properties will be stored in a dictionary with its ID serving as the key to access the data about the badge.

## Updating doors on an existing badge
---
The user will be asked to either add or remove a door. A list of all the badges and the doors they can access will be shown to the user. The user will then be asked to provide the badge ID to update and the door name to add or remove.

## Delete all doors from an existing tree
---
The user will be shown a list of all the badges and the doors they can access. The user will then be asked to provide the ID for the badge that needs to be cleared of all doors.

## Showing a list of all badges
---
The list of badges will be shown in the following format
```
BadgeID	 DoorAccess
12345	 A7
22345	 A1 A4 B1 B2
32345	 A4 A5
```
