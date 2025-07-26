
# RoomKid Project

## Requirements
- **Unity Version:** 6.0.51  
---
- **Third-Party Plugins & Packages:**  
  - Zenject  
  - RoomKid Pack  

---

## How It Works
This is the **RoomKid** environment where several items are interactable:  
- **TV**  
- **Ball**  
- **Arcade Game**  
- **Fan**

### Core Features
- **Sadness Mode:**  
  A button switches the environment to *Sadness Mode*, changing the atmosphere to something gloomy and depressing—because apparently that's fun.  

- **Mouse Rotation:**  
  Hold right mouse button to enable rotation mode

---


## Technical Overview
- **Zenject:**  
  A dependency injection framework used to connect core classes like `GameManager` and `ApiManager`.  

- **ApiManager:**  
  Handles API calls using **UnityWebRequest**.  
  - Makes **GET** API requests.  
  - Dispatches responses to other classes via an **EventSystem**.

- **Interaction System:**  
  Each interactable item (TV, Ball, etc.) has its own **controller** class with custom behavior.  
  These controllers **inherit from a common `Interaction` base class**, allowing polymorphic handling of different interactions.

---

## Sadness Mode Logic
Switching to *Sadness Mode* involves:
- Changing the **Global Volume** to a different atmosphere profile.  
- The **Tom & Jerry cartoon** switches to a sad version.  
- The **RoomKid character** reacts by becoming sad.  
