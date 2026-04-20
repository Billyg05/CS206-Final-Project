Week 4 Test Log

Project
- Hair Salon Management App week 4

Advanced Features:
- Employee account creation with secure salted password hashing
- Appointment search and filtering by text, service, and date

Testing Summary
- all features work as intended

everything tested:

Startup And Login
- Program opens without startup errors
- Default login works with username `admin`
- Default login works with password `Salon123`
- Login fails with wrong password
- Login fails with blank password
- Login fails with invalid username format
- Logout returns user to login screen

Employee Account Feature
- New employee account can be created from dashboard
- Username is converted and saved in lowercase format
- Duplicate username is blocked
- Password confirmation mismatch is blocked
- Password without uppercase letter is blocked
- Password without lowercase letter is blocked
- Password without number is blocked
- Password with spaces is blocked
- Newly created employee account can log in after save

Customer Entry
- Customer can be added successfully
- Blank customer name is blocked
- Customer name with invalid characters is blocked
- Phone number must be 10 digits
- Invalid email format is blocked
- Notes longer than allowed limit are blocked
- Duplicate customer with same name and phone is blocked

Appointment Create
- Appointment can be created using existing customer
- Appointment requires customer selection
- Appointment requires service selection
- Appointment requires stylist selection
- Notes save correctly when left blank
- Notes save correctly when short text is entered
- Appointment price follows selected service
- Appointment cannot be booked in the past
- Appointment cannot be booked before 9:00 AM
- Appointment cannot be booked after 6:00 PM
- Same stylist cannot be double-booked at same date/time
- Same customer cannot be double-booked at same date/time

Appointment Read Search Filter
- Saved appointment appears in Manage Records
- Search finds appointment by appointment ID
- Search finds appointment by customer name
- Search finds appointment by service name
- Search finds appointment by stylist name
- Service dropdown filter narrows results correctly
- Date filter narrows results correctly
- Reset button clears all filters and reloads full list
- Refresh button reloads the grid correctly

Appointment Update
- Edit button opens selected appointment
- Edited appointment saves correctly
- Edited appointment keeps customer/service/stylist selection correctly
- Edited appointment updates date/time correctly
- Edited appointment still follows duplicate-booking rules

Appointment Delete
- Delete button removes selected appointment
- Delete confirmation appears before delete
- Canceling delete leaves record unchanged

Reports And Dashboard
- Dashboard customer count updates after adding customer
- Dashboard appointment count updates after booking
- Dashboard today count updates when appointment is for today
- Dashboard revenue updates after saving appointment
- Reports screen opens without error
- Reports screen shows customer count
- Reports screen shows appointment count
- Reports screen shows total revenue
- Reports screen shows top service
- Reports list updates after create/edit/delete actions

Persistence
- Customer data still exists after closing and reopening program
- Employee data still exists after closing and reopening program
- Appointment data still exists after closing and reopening program
- Report totals still match saved data after reopening

Known Bugs / Notes
- No critical bugs found during current testing
- Demo data only resets if the `DataFiles` folder is deleted and the program is reopened
- Customer management is add-only; there is no separate customer edit/delete form yet
- Employee management is add/login only; there is no full employee maintenance screen
