// ======================================== Part 1 ==================================
//Values at the same index belong to the same session.

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System.Globalization;
using System.Text;
using BenchmarkDotNet.Running;
using AcademyScheduleAnalyzer;



string[] sessionNames = { "C# Basics", "Arrays", "Functions", "Date and Time", "Exception Handling" };

DateTime[] sessionDates = {
    new DateTime(2026,9,10,18,0,0) ,
    new DateTime(2026,9,13,18,0,0) ,
    new DateTime(2026,9,17,18,0,0) ,
    new DateTime(2026,9,20,18,0,0) ,
    new DateTime(2026,9,24,18,0,0) };

int[] sessionDurations = { 180, 240, 180, 240, 180 };

int option;

Console.WriteLine(" =============================== \n Academy Schdule Analyzer \n ===============================");
Console.WriteLine(" 1.Display all sessions\r\n 2.Search for a session\r\n 3. Sort session names\r\n 4. Reverse session names\r\n 5. Find session index\r\n 6. Check if session exists\r\n 7. Show duration statistics\r\n 8. Show session date details\r\n 9. Show past and upcoming sessions\r\n 10. Find next session\r\n 11. Compare two session dates\r\n 12. Read and validate a custom date\r\n 13. Select session by index\r\n 14. Validate session duration\r\n 15. Generate report using string\r\n 16.Generate report using StringBuilder\r\n 0.Exit");
do
{
    Console.Write("\n Choose an option: ");
    bool parsed = int.TryParse(Console.ReadLine(), out option);
    while (!parsed)
    {
        Console.WriteLine("Invalid option please choose number from list");
        parsed = int.TryParse(Console.ReadLine(), out option);
    }


    switch (option)
    {
        case 0:
            Console.WriteLine(" ============== Thanks for using my Analyzer ================");
            break;
        case 1:
            DisplayAllSessionsWithDetails(sessionNames, sessionDates, sessionDurations);
            break;
        case 2:
            SearchSessionByName();
            break;
        case 3:
            SortSessionNames(sessionNames);
            break;
        case 4:
            ReveseSessionNames(sessionNames);
            break;
        case 5:
            FindSessionIndex(sessionNames);
            break;
        case 6:
            CheckIfSessionExist(sessionNames);
            break;
        case 7:
            DurationAnalyzer(sessionDurations);
            break;
        case 8:
            showSessionDateDetails();
            break;
        case 9:
            sessionStatus();
            break;
        case 10:
            FindNextSession();
            break;
        case 11:
            Console.WriteLine(" Enter First session name");
            string session1 = Console.ReadLine();
            Console.WriteLine("Enter Second session name");
            string session2 = Console.ReadLine();
            DateDifference(session1, session2);
            break;
        case 12:
            ValidateADate();
            break;
        case 13:
            GetSessionByIndex();
            break;
        case 14:
            ValidateSessionDuration();
            break;
        case 15:
            SchduleReportWithString();
            break;
        case 16:
            SchduleReportWithStringBuilder();
            break;
        default:
            Console.WriteLine("Choose number from list");
            break;
    }

} while (option != 0);






//DisplayAllSessionsWithDetails(sessionNames, sessionDates, sessionDurations);
//SearchSessionByName("hand");
//SortSessionNames(sessionNames);

//DurationAnalyzer(sessionDurations);
//SortAndDisplayDurations(sessionDurations);

// Testing benchmark 
//BenchmarkRunner.Run<StringBenchMark>();

// ======================================== Part 2 ==================================
// Function to display each session with it's details
void DisplayAllSessionsWithDetails(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
{
    for (int i = 0; i < sessionNames.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {sessionNames[i]} \n Date: {sessionDates[i].ToString("dd MMMM yyyy")} \n Start: {sessionDates[i].ToString("t")} \n Duration: {sessionDurations[i]} Minutes \n");
    }

}

// ======================================== Part 3 ==================================
//Search session by name
void SearchSessionByName()
{

    Console.WriteLine("Enter SessionName");
    string sessionName = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(sessionName))
    {
        Console.WriteLine("Please Enter valid Session Name");
        sessionName = Console.ReadLine();

    }


    // Get sessionn index
    int index = Array.FindIndex(
       sessionNames,
       name => name.Contains(sessionName, StringComparison.OrdinalIgnoreCase)
   );
    if (index == -1)
    {
        Console.WriteLine("Session not found");
        return;
    }

    Console.WriteLine($"Name: {sessionNames[index]} \n Date: {sessionDates[index].ToString("dd MMMM yyyy")} \n Start Time: {sessionDates[index].ToString("t")} \n Duration: {sessionDurations[index]} Minutes \n");


}


// ======================================== Part 4 ==================================
// ======= Array Methods Practice =========


//Console.WriteLine(" \n ============================ Start PART 4 =================== \n");


string[] copiedSessionNames = new string[sessionNames.Length];
Array.Copy(sessionNames, copiedSessionNames, sessionNames.Length);
string[] MakeACopyOfSessionNames(string[] sessionNames)
{
    string[] copiedSessionNames = new string[sessionNames.Length];
    Array.Copy(sessionNames, copiedSessionNames, sessionNames.Length);
    return copiedSessionNames;
}

//4.1 --> Sort sessionNames
void SortSessionNames(string[] sessionNames)
{
    string[] copiedSessionNames = MakeACopyOfSessionNames(sessionNames);
    Array.Sort(copiedSessionNames);
    Console.WriteLine(" SessionNames array sorted Alphabetically");
    foreach (var session in copiedSessionNames)
    {
        Console.WriteLine(" " + session);
    }
}


//4.2 --> reverse array
void ReveseSessionNames(string[] sessionNames)
{
    string[] copiedSessionNames = MakeACopyOfSessionNames(sessionNames);
    Console.WriteLine(" Reversed SessionNames array ");
    Array.Reverse(copiedSessionNames);
    foreach (var session in copiedSessionNames)
    {
        Console.WriteLine(" " + session);
    }
}


//4.3 --> find session index

void FindSessionIndex(string[] sessionNames)
{
    Console.WriteLine("Enter session name");
    string sessionName = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(sessionName))
    {
        int requiredSessionIndex = Array.FindIndex(
       sessionNames,
       name => name.Contains(sessionName, StringComparison.OrdinalIgnoreCase));
        if (requiredSessionIndex != -1)
        {
            Console.WriteLine($"Session index is => {requiredSessionIndex}");
        }
        else
        {
            Console.WriteLine("session not found");
        }
    }
}



//4.4 --> check if session exist
void CheckIfSessionExist(string[] sessionNames)
{
    Console.WriteLine("Enter session name");
    string sessionName = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(sessionName))
    {
        if (Array.Exists(sessionNames, name => name.Equals(sessionName, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"Session exists");
        }
        else
        {
            Console.WriteLine("session doesn't exist");
        }
    }
    else
    {
        Console.WriteLine("try again and enter valid name");
    }
}


////4.5 --> Find a session
void FindSessionAndDisplayName()
{
    Console.WriteLine("Enter session name");
    string sessionName = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(sessionName))
    {
        string matched = Array.Find(sessionNames, name => name.Contains(sessionName, StringComparison.OrdinalIgnoreCase));
        if (string.IsNullOrEmpty(matched))
        {
            Console.WriteLine("Couldn't find session");
        }
        else
        {
            Console.WriteLine(matched);
        }
    }
    else
    {
        Console.WriteLine("try again and enter valid name");
    }
}


//4.6 --> Find a session index based on condition
//Console.WriteLine("Enter session name");
//string sessionName = Console.ReadLine();
//if (!string.IsNullOrWhiteSpace(sessionName))
//{
//    int matchedIndex = Array.FindIndex(copiedSessionNames, name => name.Contains(sessionName, StringComparison.OrdinalIgnoreCase));
//    if (matchedIndex == -1)
//    {
//        Console.WriteLine("Couldn't find session");
//    }
//    else
//    {
//        Console.WriteLine("index: " + matchedIndex);
//    }
//}
//else
//{
//    Console.WriteLine("try again and enter valid name");
//}


//4.7 --> Copying an array
//Console.WriteLine("Original Array after modification");
//Console.WriteLine();
//for (int i = 0; i < sessionNames.Length; i++)
//{
//    Console.WriteLine(sessionNames[i]);
//}
//Console.WriteLine();
//copiedSessionNames[0] = "C++";
//Console.WriteLine("Copied Array after modification");
//Console.WriteLine();
//for (int i = 0; i < copiedSessionNames.Length; i++)
//{
//    Console.WriteLine(copiedSessionNames[i]);
//}


//Console.WriteLine(" \n ============================ End PART 4 =================== \n");



// =================================== End Part 4 ==================================

// ====================== Part 5  (Duration Analysis) ==============================
//FUNCTION TO ANALYIZE DURATIONS
void DurationAnalyzer(int[] sessionDurations)
{
    int total = CalculateTotalDurations(sessionDurations);
    double average = CalculateAverageDurations(sessionDurations);
    int shortest = GetShortestDuration(sessionDurations);
    int longest = GetLongestDuration(sessionDurations);

    Console.WriteLine($" Total duration : {total} minutes");
    Console.WriteLine($" Average duration : {average} minues");
    Console.WriteLine($" Longest duration : {longest} minues");
    Console.WriteLine($" Shortest duration : {shortest} minues");

}

//Function to calculate total
int CalculateTotalDurations(int[] sessionDurations)
{
    int total = 0;
    foreach (int duration in sessionDurations)
    {
        total += duration;
    }

    return total;
}

double CalculateAverageDurations(int[] sessionDurations)
{
    return (double)(CalculateTotalDurations(sessionDurations) / sessionDurations.Length);
}

int GetShortestDuration(int[] sessionDurations)
{
    int shortest = sessionDurations[0];

    foreach (int duration in sessionDurations)
    {

        if (duration < shortest)
            shortest = duration;

    }

    return shortest;
}
int GetLongestDuration(int[] sessionDurations)
{
    int longest = sessionDurations[0];

    foreach (int duration in sessionDurations)
    {

        if (duration > longest)
            longest = duration;

    }

    return longest;
}
void SortAndDisplayDurations(int[] sessionDurations)
{
    int[] copied = new int[sessionDurations.Length];
    Array.Copy(sessionDurations, copied, sessionDurations.Length);
    Array.Sort(copied);
    Console.WriteLine($" Sorted durations");
    foreach (int duration in copied)
    {
        Console.WriteLine(" " + duration);
    }
}


// ====================== Part 6  (Creating functions) ==============================
// first seven methods of this part already done above
DateTime GetSessionEndTime(string sessionName)
{
    int index = Array.FindIndex(
       sessionNames,
       name => string.Equals(
           name,
           sessionName,
           StringComparison.OrdinalIgnoreCase)
   );

    if (index == -1)
    {
        return DateTime.MinValue;
    }

    DateTime startTime = sessionDates[index];
    int duration = sessionDurations[index];

    return startTime.AddMinutes(duration);

}


// =========================== Part 7 =====================
// 7.1

//Console.WriteLine(" \n ============================ Start PART 7 =================== \n");

//int value = 5;
//Console.WriteLine($"Value before sending it by ref to function = {value}");
//void ModifyVarValue(ref int x)
//{
//    x += 3;
//}
//ModifyVarValue(ref value);
//Console.WriteLine($"Value after = {value}");

//Console.WriteLine(" \n ============================ END PART 7 =================== \n");


// 7.2

int sessionIndex, sessionDuration;
void GetSessionIndexAndDuration(string? sessionName, out int sessionIndex, out int sessionDuration)
{
    sessionIndex = Array.FindIndex(sessionNames, name => name.Equals(sessionName, StringComparison.OrdinalIgnoreCase));
    if (sessionIndex == -1)
    {
        Console.WriteLine("Session name not found ");
        sessionDuration = 0;
        return;
    }

    sessionDuration = sessionDurations[sessionIndex];
    Console.WriteLine($" Session index = {sessionIndex} \n Session Duration = {sessionDuration}");
}
//Console.WriteLine("Enter Session Name");
//string sessionName = Console.ReadLine();
//GetSessionIndexAndDuration(sessionName, out sessionIndex, out sessionDuration);


//7.3

int[] arr = { 1, 2, 3 };
void ChangeArrayValue(int[] arr)
{
    Console.WriteLine(" Array elements before updating");
    foreach (int x in arr)
    {
        Console.WriteLine(x);
    }
    arr[0] = 30000;
    Console.WriteLine(" Array elements After updating");
    foreach (int x in arr)
    {
        Console.WriteLine(x);
    }
}

//ChangeArrayValue(arr);


// =========================== Part 8 ========================

int CalculateTotalDuration(params int[] durations)
{
    int totalDuration = 0;
    foreach (int duration in durations)
    {
        totalDuration += duration;
    }
    return totalDuration;
}

//Console.WriteLine($"Total duration is = {CalculateTotalDuration(180,220)}");


// ======================== Part 9 =========================
void showSessionDateDetails()
{
    Console.WriteLine("Enter Session Name");
    string sessionName = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(sessionName))
    {
        Console.WriteLine("Please enter valid name");
        return;
    }
    int sessionIndex = Array.FindIndex(sessionNames, name => name.Contains(sessionName, StringComparison.OrdinalIgnoreCase));

    if (sessionIndex == -1)
    {
        Console.WriteLine("Session name not found ");
        return;
    }

    DateTime sessionDate = sessionDates[sessionIndex];
    Console.WriteLine($"Full date: {sessionDate.ToString("d")}");
    Console.WriteLine($"Day of week: {sessionDate.DayOfWeek}");
    Console.WriteLine($"Year: {sessionDate.Year}");
    Console.WriteLine($"Month: {sessionDate.Month}");
    Console.WriteLine($"Day: {sessionDate.Day}");
    Console.WriteLine($"Start time: {sessionDate.ToString("t")}");
    Console.WriteLine($"Duration: {sessionDurations[sessionIndex]}");
    DateTime endDate = sessionDate.AddMinutes(sessionDurations[sessionIndex]);
    Console.WriteLine($"End Time: {endDate.ToString("t")}");

}
//showSessionDateDetails();


// ====================== Part 10  (Date Fifference) ==============================

void DateDifference(string session1 = "", string session2 = "")
{

    int session1Index = Array.FindIndex(sessionNames, name => name.Contains(session1, StringComparison.OrdinalIgnoreCase));
    int session2Index = Array.FindIndex(sessionNames, name => name.Contains(session2, StringComparison.OrdinalIgnoreCase));
    if (session1Index == -1 || session2Index == -1)
    {
        Console.WriteLine("Session not found please check sessions names");
        return;
    }
    DateTime session1Date = sessionDates[session1Index];
    DateTime session2Date = sessionDates[session2Index];
    TimeSpan differenceDate;
    if (session1Date > session2Date)
    {
        differenceDate = session1Date - session2Date;
    }
    else
    {
        differenceDate = session2Date - session1Date;

    }

    Console.WriteLine($" Firt session : {sessionNames[session1Index]} \n Second session : {sessionNames[session2Index]}");

    Console.WriteLine("Difference");
    Console.WriteLine($" Days : {differenceDate.Days} \n Hours : {differenceDate.Hours}");

}

// ====================== Part 11  (Past and Upcomming Sessions) ==============================

void sessionStatus()
{
    DateTime x = DateTime.Now;
    TimeSpan difference;
    for (int i = 0; i < sessionNames.Length; i++)
    {
        difference = sessionDates[i] - x;
        if (difference.TotalDays > 0)
        {
            Console.WriteLine($" {sessionNames[i]} : Upcoming");
        }
        else
        {
            Console.WriteLine($" {sessionNames[i]} : Past");
        }

    }
}


// ====================== Part 12  (Find the next session) ==============================

void FindNextSession()
{
    DateTime x = DateTime.Now;
    TimeSpan difference;
    int nextSessioIndex = Array.FindIndex(sessionDates, date => date > x);
    if (nextSessioIndex == -1)
    {

        Console.WriteLine(" There is no Upcoming sessions");
    }
    else
    {
        difference = sessionDates[nextSessioIndex] - x;
        Console.WriteLine($" Next Session: \n \n {sessionNames[nextSessioIndex]} \n {sessionDates[nextSessioIndex].ToString("dd MMMM yyyy")} ");
        Console.WriteLine($" {sessionDates[nextSessioIndex].ToString("t")} \n ");
        Console.WriteLine(" Time remaining : \n ");
        Console.WriteLine($" Days: {difference.Days}");
        Console.WriteLine($" Hours: {difference.Hours}");

    }
}

// ====================== Part 13  (Date Formating) ==============================

void DateFormats()
{
    Console.WriteLine($" Session : {sessionNames[0]}");
    Console.WriteLine($" Date : ");
    Console.WriteLine($" {sessionDates[0].ToString("yyyy-MM-dd")} ");
    Console.WriteLine($" {sessionDates[0].ToString("d")} ");
    Console.WriteLine($" {sessionDates[0].ToString("dd MMMM yyyy")} ");
    Console.WriteLine($" {sessionDates[0].ToString("D")} ");
    Console.WriteLine($" {sessionDates[0].ToString("t")} ");
}


// ====================== Part 14  (Read & Validate a Date) ==============================

DateTime ValidateADate()
{
    string input;
    DateTime result;

    do
    {
        Console.WriteLine("Enter a date in this format yyyy-MM-dd HH:mm ");
        input = Console.ReadLine();

    } while (!DateTime.TryParseExact(input, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out result));

    return result;
}

//Console.WriteLine(ValidateADate());


// ====================== Part 15  (Exception Handling Menu Input) ==============================

void ChooseOption()
{
    bool isValid = true;
    int option = 0;
    do
    {
        try
        {

            Console.Write("Choose an option : ");
            option = int.Parse(Console.ReadLine());
            isValid = true;
        }
        catch (FormatException ex)
        {
            Console.WriteLine(" Invalid Menu Option Please Enter Valid Numeric Input");
            isValid = false;
        }
    } while (!isValid);

    Console.WriteLine($"Your Selected Option is : {option} ");

}

//ChooseOption();

// ====================== Part 16  (Exception Handling Invalid array index ) ==============================

void InvalidArrayIndexHandle()
{
    int index = 0;
    try
    {
        Console.Write("Write An Array Index : ");
        index = int.Parse(Console.ReadLine());
        Console.WriteLine($" Session : {sessionNames[index]}");
    }
    catch (IndexOutOfRangeException ex)
    {
        Console.WriteLine("The selected session index is out of range.");
    }



}
//InvalidArrayIndexHandle();


// ====================== Part 17  (Exception Handling : Throw exception ) ==============================

void ValidateSessionDuration()
{
    Console.WriteLine(" Enter Numerical Duration ");
    int duration;
    bool isParsed = int.TryParse(Console.ReadLine(), out duration);
    while (!isParsed)
    {
        Console.WriteLine("Enter numerical reasonable duration");
        isParsed = int.TryParse(Console.ReadLine(), out duration);
    }

    if (duration <= 0)
    {
        throw new ArgumentException();
    }

    Console.WriteLine(" Duration Accepted");
}

//test method
//try
//{
//    Console.WriteLine("Enter session duration greater than zero");
//    int duration = int.Parse(Console.ReadLine());
//    ValidateSessionDuration(duration);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}


// ====================== Part 18  (Exception Handling : with finally ) ==============================

void ChooseOptionWithFinally()
{

    try
    {

        Console.Write("Choose an option : ");
        int option = int.Parse(Console.ReadLine());
        Console.WriteLine(option);

    }
    catch (FormatException ex)
    {
        Console.WriteLine(" Invalid Menu Option Please Enter Valid Numeric Input");

    }
    finally
    {
        Console.WriteLine("Input operation finished.");
    }




}

//ChooseOptionWithFinally();

// ====================== Part 19  (Schdule report with string ) ==============================

void SchduleReportWithString()
{
    string result = "";
    for (int i = 0; i < sessionNames.Length; i++)
    {
        result += sessionNames[i] + " - " + sessionDates[i] + " - " + sessionDurations[i] + " Minutes \n";

    }
    Console.WriteLine(result);
}

//SchduleReportWithString();

// ====================== Part 20  (Schdule report with stringBuilder ) ==============================

void SchduleReportWithStringBuilder()
{
    Console.WriteLine("\n Report using StrinBuilder \n");
    StringBuilder result = new StringBuilder("");
    for (int i = 0; i < sessionNames.Length; i++)
    {
        result.Append(sessionNames[i] + " - " + sessionDates[i] + " - " + sessionDurations[i] + " Minutes \n");

    }
    Console.WriteLine(result);
}

//SchduleReportWithStringBuilder();


void GetSessionByIndex()
{
    Console.WriteLine("Enter session index");
    bool isParsed = int.TryParse(Console.ReadLine(), out int sessionIndex);
    while (!isParsed)
    {
        Console.WriteLine("Enter numerical value");
        isParsed = int.TryParse(Console.ReadLine(), out sessionIndex);
    }

    while (sessionIndex < 0 || sessionIndex > sessionNames.Length - 1)
    {
        Console.WriteLine(" Enter valid index from 0 to 3");
        isParsed = int.TryParse(Console.ReadLine(), out sessionIndex);
        while (!isParsed)
        {
            Console.WriteLine("Enter numerical value");
            isParsed = int.TryParse(Console.ReadLine(), out sessionIndex);
        }
    }

    Console.WriteLine($"\n Session is : {sessionNames[sessionIndex]} \n");


}


