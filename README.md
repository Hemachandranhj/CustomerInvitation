# CustomerInvitation
 Console App to find and invite customers within the given distance using great-circle distance formulae

# The Invitation App is a console application.
 * It takes GPS coordinates and distance(in km) as an input from the user. E.g.53.339428, -6.257664 and 100.
 * It fetches the customers list from the input file(customers.txt) and applies great circle distance formulae to filter the customers within the provided range.
 * It writes the filtered customers into the output file (outputCustomer.txt).
 
# Technical details
 * Framework: .NET Core 3.0
 * Language: C# 8.0
 * IDE: Visual Studio 2019
 * Operation System: Windows 10

# How to run the application?
 * Download the publish folder and execute the "InvitationApp.exe"
 * Enter the coordinates in Latitude, Longitude format
 * Enter the distance in kilo meter
 * The app will calculate and return the results into the output file(outputCustomers.txt).
 
# How to run the unit tests
 Download and install "Download .NET Core Runtime" from the below link
 https://dotnet.microsoft.com/download
 Steps to execute the test
 1. Open the command prompt
 2. Go to the project folder(path to be updated)
 3. Run the command "dotnet test InvitationApp.Tests.dll"
  In case the step 3 doesn't work, please install the visual studio 2019 from the below URL
  Link to download 2019 and retry step 3.
 4. You should see the test results executed successfully.
