Hair Salon Management App

Overview
- Windows Forms salon app for employee login, customer entry, appointment booking, record management, and reports.
- Data saves automatically to text files in the `DataFiles` folder next to the built program.

Advanced Features
- Employee account creation with salted password hashing
- Appointment search and filtering by text, service, and date
- Duplicate appointment blocking for stylists and customers

Default Login
- Username: `admin`
- Password: `Salon123`

Demo Data
- First run seeds:
  - 1 employee account
  - 2 customers
  - 4 services
  - 3 stylists
  - 2 sample appointments

How To Use
1. Run the program.
2. Log in with the default account or create a new employee account from the dashboard.
3. Use `Add Customer` to add more customers.
4. Use `Book Appointment` to create or edit appointments.
5. Use `Manage Records` to search, filter, edit, delete, and refresh appointments.
6. Use `Reports` to view totals and service counts.

CRUD Test
1. Open `Book Appointment`.
2. Select a customer, service, stylist, date, and time.
3. Save the appointment.
4. Open `Manage Records` and find the appointment.
5. Click `Edit`, change something, and save.
6. Select the same row and click `Delete`.

Reset Data
- Close the program.
- Delete the `DataFiles` folder in the output folder.
- Run the program again to recreate the demo data.
