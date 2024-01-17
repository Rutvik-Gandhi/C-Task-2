using System;

class client
{
    // class for client related information
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LasttName { get; set; }
    public string? Gender { get; set; }
    public string? BirthDate { get; set; }
    public string? PatientNumber { get; set; }

}

class AvailableAppointments
{
    // create a slot class where i'll show all appointments
    public string[]? slots = {
        "8:00 AM to 9:00 AM",
        "9:00 AM to 10:00 AM",
        "10:00 AM to 11:00 AM",
        "11:00 AM to 12:00 PM",
        "1:00 PM to 2:00 PM",
        "2:00 PM to 3:00 PM",
        "3:00 PM to 4:00 PM"
    };
}

class services : client
{
    // using inheritance
    public string? serviceName { get; set; }
    public int serviceId { get; set; }
    public double? price { get; set; }
}

class ScheduleAppointment : services
{
    // using inheritance
    public int slotNumber { get; set; }

}

class dental
{
    
    public static void Main(string[] args)
    {
        Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-* Dental Clinic *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");

        // using try and catch method here
        try
        {
            List<services> service = new List<services>();
            List<client> clientList = new List<client>();
            List<ScheduleAppointment> bookedAppointments = new List<ScheduleAppointment>();

            service.Add(new services() { serviceName = "Cleaning", serviceId = 1,});
            service.Add(new services() { serviceName = "Cavity Fill", serviceId = 2,});
            service.Add(new services() { serviceName = "Check-up", serviceId = 3,});
            service.Add(new services() { serviceName = "X-Ray", serviceId = 4,});
            service.Add(new services() { serviceName = "Braces Fitting (Child Only)", serviceId = 5,});
            service.Add(new services() { serviceName = "Veneers (Adult Only)", serviceId = 6,});
            service.Add(new services() { serviceName = "Dentures (Seniors Only)", serviceId = 7,});

            // showing 10 hhard code clients data
            clientList.Add(new client() { Id = 1, FirstName = "Rutvik", LasttName = "Gandhi", Gender = "Male", BirthDate = "01/01/2000", PatientNumber = "1234567890" });
            clientList.Add(new client() { Id = 2, FirstName = "Salim", LasttName = "Sema", Gender = "Male", BirthDate = "02/10/1995", PatientNumber = "2345678901" });
            clientList.Add(new client() { Id = 3, FirstName = "Ricky", LasttName = "Satyam", Gender = "Male", BirthDate = "05/05/1989", PatientNumber = "3456789012" });
            clientList.Add(new client() { Id = 4, FirstName = "Dhruvi", LasttName = "Gandhi", Gender = "Female", BirthDate = "01/12/1998", PatientNumber = "4567890123" });
            clientList.Add(new client() { Id = 5, FirstName = "Jay", LasttName = "Mehta", Gender = "Male", BirthDate = "03/21/1992", PatientNumber = "5678901234" });
            clientList.Add(new client() { Id = 6, FirstName = "Rajesh", LasttName = "Gajjar", Gender = "Male", BirthDate = "05/20/1998", PatientNumber = "6789012345" });
            clientList.Add(new client() { Id = 7, FirstName = "Harshali", LasttName = "patel", Gender = "Female", BirthDate = "09/02/1997", PatientNumber = "7890123456" });
            clientList.Add(new client() { Id = 8, FirstName = "Nirmalli", LasttName = "Solanki", Gender = "Female", BirthDate = "05/14/1988", PatientNumber = "8901234567" });
            clientList.Add(new client() { Id = 9, FirstName = "Hiren", LasttName = "Patel", Gender = "Male", BirthDate = "10/15/1989", PatientNumber = "9012345678" });
            clientList.Add(new client() { Id = 10, FirstName = "Jamani", LasttName = "Sagar", Gender = "Female", BirthDate = "12/23/1990", PatientNumber = "0123456789" });

            //Already Booked Slots
            bookedAppointments.Add(new ScheduleAppointment() { slotNumber = 2, Id = 1, serviceId = 2 });
            bookedAppointments.Add(new ScheduleAppointment() { slotNumber = 7, Id = 5, serviceId = 3 });

            services getServiceById(int Serviceid)
            {
                var serviceData = service.Find(serv => serv.serviceId == Serviceid);

                if (serviceData != null)
                {
                    return serviceData!;
                }
                else
                {
                    return null!;
                }
            }

            client getClientById(int clientId)
            {
                var client = clientList.Find(cli => cli.Id == clientId);

                if (client != null)
                {
                    return client!;
                }
                else
                {
                    return null!;
                }
            }

            bool scheduleNewAppointment(int slotId, int customerId, int serviceId)
            {
                var checkingExist = bookedAppointments.Find(appointment => appointment.slotNumber == slotId);

                Console.WriteLine(checkingExist?.Id);

                if (checkingExist != null)
                {
                    if (checkingExist?.Id == customerId)
                    {
                        Console.WriteLine("This Slot is already occupied same customer");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("This Slot is already occupied");
                        return false;
                    }
                }
                else
                {
                    bookedAppointments.Add(new ScheduleAppointment() { slotNumber = slotId, Id = customerId, serviceId = serviceId });
                    return true;
                }

            }

            // Data about booked appointments

            void showingAllBookedAppointment()
            {
                foreach (ScheduleAppointment appointment in bookedAppointments)
                {
                    Console.WriteLine("  ");
                    Console.WriteLine("Slot Id: {0}", appointment.slotNumber);
                    Console.WriteLine("Client Id: {0}", appointment.Id);

                    var customerData = getClientById(appointment.Id);
                    Console.WriteLine("Client Name: {0} {1}", customerData.FirstName, customerData.LasttName);
                    Console.WriteLine("Client Gender: {0}", customerData.Gender);
                    Console.WriteLine("Client Number: {0}", maskInitials(customerData.PatientNumber));

                    var serviceData = getServiceById(appointment.serviceId);
                    Console.WriteLine("Service: {0}", serviceData.serviceName);
                }
            }

            bool isLoop = true;
            // using while loop
            while (isLoop)
            {
                clinicMenu();
                Console.Write(" Enter Your Choice: ");
                int? choice = Convert.ToInt32(Console.ReadLine());

                // using switch case here

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-* Display Client List *-*-*-*-*-*-*-*-*-*-");
                        displayPersons(clientList);
                        break;

                    case 2:
                        Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-* Create Schedule *-*-*-*-*-*-*-*-*-*-*-*-*-");

                        displayAvailableSlots(bookedAppointments);

                        Console.WriteLine("Enter slot number you wish to booked");
                        int putSlotId = Convert.ToInt32(Console.ReadLine());

                        if (putSlotId <= 0 || putSlotId > 8)
                        {
                            Console.WriteLine("Please enter valid slot number !!! ");
                            break;
                        }

                        Console.WriteLine("Enter customer Id");
                        int enterClientId = Convert.ToInt32(Console.ReadLine());

                        if (enterClientId <= 0 || enterClientId > 10)
                        {
                            Console.WriteLine("Please enter valid customer Id (from 1 to 10) !!! ");
                            break;
                        }

                        displayService(service);

                        Console.WriteLine("Enter Service Id");
                        int enterServiceId = Convert.ToInt32(Console.ReadLine());

                        scheduleNewAppointment(putSlotId, enterClientId, enterServiceId);

                        break;

                    case 3:
                        Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-* Display Todays Schedule *-*-*-*-*-*-*-*-*-*-*-*-*-");

                        showingAllBookedAppointment();

                        Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");

                        break;

                    case 4:
                        Console.WriteLine("-*-*-*-*-*-*-*-*-* Exit *-*-*-*-*-*-*-*-*-*");
                        isLoop = false;
                        break;

                    default:
                        Console.WriteLine("Please enter valid choice option !!!");
                        break;
                }

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    // showing availableslots for clients
    public static void displayAvailableSlots(List<ScheduleAppointment> listOfBookedAppointment)
    {
        List<int> bookedSlots = new List<int>();

        foreach (ScheduleAppointment booked in listOfBookedAppointment)
        {
            bookedSlots.Add(booked.slotNumber);
        }

        int[] bookSlot = bookedSlots.ToArray();

        Console.WriteLine(" -*-*-*-*-*-*-*-*-*-*-* Available Slots *-*-*-*-*-*-*-*-*-*-*-*-");

        if (!bookSlot.Contains(1))
        {
            Console.WriteLine(" (1) 8:00 AM to 9:00 AM");
        }

        if (!bookSlot.Contains(2))
        {
            Console.WriteLine(" (2) 9:00 AM to 10:00 AM");
        }

        if (!bookSlot.Contains(3))
        {
            Console.WriteLine(" (3) 10:00 AM to 11:00 AM");
        }

        if (!bookSlot.Contains(4))
        {
            Console.WriteLine(" (4) 11:00 AM to 12:00 PM");
        }

        if (!bookSlot.Contains(5))
        {
            Console.WriteLine(" (5) 12:00 PM to 1:00 PM");
        }

        if (!bookSlot.Contains(6))
        {
            Console.WriteLine(" (6) 1:00 PM to 2:00 AM");
        }

        if (!bookSlot.Contains(7))
        {
            Console.WriteLine(" (7) 2:00 PM to 3:00 PM");
        }

        if (!bookSlot.Contains(8))
        {
            Console.WriteLine(" (8) 3:00 PM to 4:00 PM");
        }
    }

    // Display client details

    public static void displayPersons(List<client> listOfClients)
    {
        foreach (client clientIs in listOfClients)
        {
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-");

            Console.WriteLine("Customer Id:      {0}", clientIs.Id);
            Console.WriteLine("First Name:       {0}", clientIs.FirstName);
            Console.WriteLine("Last Name:        {0}", clientIs.LasttName);
            Console.WriteLine("Gender:           {0}", clientIs.Gender);
            Console.WriteLine("Birthdate:        {0}", clientIs.BirthDate);
            Console.WriteLine("Patient Number:   {0}", maskInitials(clientIs.PatientNumber));

            Console.WriteLine("  ");
        }
    }

    public static void displayService(List<services> listOfServices)
    {
        foreach (services service in listOfServices)
        {
            Console.WriteLine("{0} \t {1} \t {2}", service.serviceId, service.serviceName, service.price);
        }
    }

    // showing MainMenu to clients

    public static void clinicMenu()
    {
        Console.WriteLine(" Available Services ");

        Console.WriteLine(" (1)  List All People");
        Console.WriteLine(" (2)  Create Schedule");
        Console.WriteLine(" (3)  Display Day Schedule");
        Console.WriteLine(" (4)  Exit");
    }

    // hide first 3 digits of patient number
    public static string maskInitials(string number)
    {
        var res = "XXX" + number.Substring(3);

        return res;
    }
}