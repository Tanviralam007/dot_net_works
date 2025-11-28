# ToolShare - Community Tool/Equipment Sharing System

## **Core Purpose**
A sustainability-focused platform that enables community members to share tools and equipment, reducing waste, saving money, and promoting resource sharing within neighborhoods.

---

## Key Workflows

1. **Owner lists tool** - Creates listing with tool details, availability calendar, and rental terms
2. **Borrower requests tool** - Searches available tools and submits booking request
3. **Owner approves/rejects** - Reviews borrower profile and approves booking
4. **Tool handover** - Records pickup details with photos and condition notes
5. **Tool return** - Records return with damage inspection and rating
6. **System tracks everything** - Status updates: Available → Requested → Approved → In Use → Returned

---

## User Roles

### Tool Owner
- Register and list tools with photos and details
- View dashboard with tool listings and earnings
- Approve/reject booking requests
- Record tool handover and return
- Rate borrowers

### Borrower
- Search and browse available tools
- Submit booking requests
- View booking history and status
- Rate tools and owners
- Report damage or issues

### Admin
- View system-wide dashboard
- Manage users and verify profiles
- Handle disputes and damage reports
- Monitor platform activity
- Generate reports

---

## Entities

### User
- **Attributes:** UserId, FullName, Email, Password, Phone, UserRole, IsActive, VerificationStatus
- **Roles:** Owner, Borrower, Admin
- **Note:** Users can be both Owner and Borrower

### Tool
- **Attributes:** ToolId, OwnerId (FK), ToolName, Category, Description, Condition, DailyRate, SecurityDeposit, IsAvailable, PhotoUrl, CreatedDate
- **Status:** Available, Rented Out, Under Maintenance

### BookingRequest
- **Attributes:** BookingId, ToolId (FK), BorrowerId (FK), RequestDate, StartDate, EndDate, TotalCost, BookingStatus, SpecialInstructions
- **Status:** Requested → Approved/Rejected → In Use → Returned → Completed

### HandoverRecord
- **Attributes:** HandoverId, BookingId (FK), HandoverDate, ToolCondition, HandoverNotes, PhotoUrl, HandedOverBy (FK)
- **Created when:** Owner hands over tool to borrower

### ReturnRecord
- **Attributes:** ReturnId, BookingId (FK), ReturnDate, ReturnCondition, DamageReport, PhotoUrl, ReceivedBy (FK), LateFee
- **Created when:** Borrower returns tool to owner

### Rating
- **Attributes:** RatingId, BookingId (FK), RatedBy (FK), RatedUser (FK), RatingScore, ReviewText, RatingDate
- **Purpose:** Track user reputation and tool quality

---

## Relationships Among Entities

### **Entity Relationships**

**User (1) ←→ (Many) Tool**  
- One user can own multiple tools  
- Each tool belongs to one owner  

**User (1) ←→ (Many) BookingRequest (as Borrower)**  
- One user can create multiple booking requests  
- Each booking request is made by one borrower  

**Tool (1) ←→ (Many) BookingRequest**  
- One tool can have multiple booking requests over time  
- Each booking request is for one specific tool  

**BookingRequest (1) ←→ (0..1) HandoverRecord**  
- Each approved booking can have one handover record  
- Created when tool pickup happens  

**BookingRequest (1) ←→ (0..1) ReturnRecord**  
- Each booking can have one return record  
- Created when tool is returned  

**BookingRequest (1) ←→ (0..2) Rating**  
- Each completed booking can have up to 2 ratings  
- One rating by borrower (for tool/owner)  
- One rating by owner (for borrower)  

**User (1) ←→ (Many) Rating (as Rater)**  
- One user can give multiple ratings  
- Each rating is given by one user  

**User (1) ←→ (Many) Rating (as Rated User)**  
- One user can receive multiple ratings  
- Each rating is for one user  

---

## DATABASE DIAGRAM
                                                ┌─────────────────┐
                                                │     Users       │
                                                │─────────────────│
                                                │ UserId (PK)     │◄─────┐
                                                │ FullName        │      │
                                                │ Email (Unique)  │      │
                                                │ Password (Hash) │      │
                                                │ Phone           │      │
                                                │ UserRole        │      │
                                                │ IsActive        │      │
                                                │VerificationStat │      │
                                                └────────┬────────┘      │
                                                         │1              │
                                                         │               │
                                                ┌────────▼────────┐      │
                                                │     Tools       │      │
                                                │─────────────────│      │
                                                │ ToolId (PK)     │      │
                                                │ OwnerId (FK)────┼──────┘
                                                │ ToolName        │
                                                │ Category        │
                                                │ Description     │
                                                │ Condition       │
                                                │ DailyRate       │
                                                │ SecurityDeposit │
                                                │ IsAvailable     │
                                                │ PhotoUrl        │
                                                └────────┬────────┘
                                                         │1
                                                         │
                                                         │*
                                                ┌────────▼────────────┐
                                                │  BookingRequests    │
                                                │─────────────────────│
                                                │ BookingId (PK)      │
                                                │ ToolId (FK)         │
                                                │ BorrowerId (FK)─────┼───┐
                                                │ RequestDate         │   │
                                                │ StartDate           │   │
                                                │ EndDate             │   │
                                                │ TotalCost           │   │
                                                │ BookingStatus       │   │
                                                │ SpecialInstructions │   │
                                                └──────┬──────────────┘   │
                                                       │1                 │
                                                 ┌─────┴─────┐            │
                                                 │1         1│            │
                                          ┌──────▼─────┐  ┌──▼──────────┐ │
                                          │Handover    │  │Return       │ │
                                          │Records     │  │Records      │ │
                                          │────────────│  │──────────── │ │
                                          │HandoverId  │  │ReturnId(PK) │ │
                                          │(PK)        │  │BookingId    │ │
                                          │BookingId   │  │(FK)         │ │
                                          │(FK)        │  │ReturnDate   │ │
                                          │HandoverDate│  │ReturnCondi  │ │
                                          │ToolConditio│  │tion         │ │
                                          │n           │  │DamageReport │ │
                                          │HandoverNote│  │PhotoUrl     │ │
                                          │s           │  │ReceivedBy   │ │
                                          │PhotoUrl    │  │(FK)         │ │
                                          │HandedOverBy│  │LateFee      │ │
                                          │(FK)        │  └─────────────┘ │
                                          └────────────┘                  │
                                                                          │
                                                ┌─────────────────────────┘
                                                │
                                        ┌───────▼────────┐
                                        │    Ratings     │
                                        │────────────────│
                                        │ RatingId (PK)  │
                                        │ BookingId (FK) │
                                        │ RatedBy (FK)   │
                                        │ RatedUser (FK) │
                                        │ RatingScore    │
                                        │ ReviewText     │
                                        │ RatingDate     │
                                        └────────────────┘


## Project Structure
```
ToolShare-Community-Platform/
│
├── Controllers/
│   ├── AccountController.cs          # Login, Register, Profile
│   ├── BaseController.cs             # Base with auth methods
│   ├── OwnerController.cs            # Manage tools, approve bookings
│   ├── BorrowerController.cs         # Search tools, create bookings
│   └── AdminController.cs            # System management
│
├── Models/ (EF Database Entities)
│   ├── User.cs
│   ├── Tool.cs
│   ├── BookingRequest.cs
│   ├── HandoverRecord.cs
│   ├── ReturnRecord.cs
│   ├── Rating.cs
│   └── ToolShareEntities.cs          # EF DbContext
│
├── DTOs/ (Data Transfer Objects)
│   ├── ToolListingDTO.cs             # For displaying tool in search
│   ├── ToolDetailsDTO.cs             # Full tool info with owner details
│   ├── BookingRequestDTO.cs          # Booking form data
│   ├── BookingSummaryDTO.cs          # Dashboard booking summary
│   ├── UserProfileDTO.cs             # Public user profile
│   ├── HandoverDTO.cs                # Handover form data
│   ├── ReturnDTO.cs                  # Return form data
│   └── DashboardStatsDTO.cs          # Dashboard statistics
│
├── ViewModels/ (UI-specific data)
│   ├── LoginViewModel.cs             # Login form validation
│   ├── RegisterViewModel.cs          # Registration form validation
│   ├── CreateToolViewModel.cs        # Create/Edit tool form
│   ├── SearchToolsViewModel.cs       # Search filters and results
│   └── RatingViewModel.cs            # Rating form
│
├── Services/ (Business Logic)
│   ├── ToolService.cs                # Tool CRUD, availability check
│   ├── BookingService.cs             # Booking logic, calculations
│   ├── RatingService.cs              # Rating calculations
│   └── NotificationService.cs        # Email/SMS notifications
│
├── Helpers/
│   ├── SessionHelper.cs
│   ├── UserRoles.cs
│   ├── CustomAuthorizeAttribute.cs
│   ├── DateHelper.cs                 # Date calculations
│   └── PriceCalculator.cs            # Rental cost calculator
│
└── Views/
    ├── Shared/
    │   └── _Layout.cshtml
    ├── Account/
    │   ├── Login.cshtml
    │   ├── Register.cshtml
    │   └── Profile.cshtml
    ├── Owner/
    │   ├── Dashboard.cshtml
    │   ├── MyTools.cshtml
    │   ├── CreateTool.cshtml
    │   ├── EditTool.cshtml
    │   ├── BookingRequests.cshtml
    │   ├── RecordHandover.cshtml
    │   └── RecordReturn.cshtml
    ├── Borrower/
    │   ├── Dashboard.cshtml
    │   ├── SearchTools.cshtml
    │   ├── ToolDetails.cshtml
    │   ├── MyBookings.cshtml
    │   ├── BookingDetails.cshtml
    │   └── RateTool.cshtml
    └── Admin/
        ├── Dashboard.cshtml
        ├── ManageUsers.cshtml
        ├── ManageTools.cshtml
        └── DamageReports.cshtml
