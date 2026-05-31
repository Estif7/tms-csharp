// EXERCISE 1
Console.WriteLine("\n--- EXERCISE 1: NULL HANDLING ---");
string? region = null; 

string? upperRegion = region?.ToUpper(); 
Console.WriteLine($"Region (conditional):{upperRegion}");

string displayRegion = region ?? "Unassigned";
Console.WriteLine($"Region (coalesced):{displayRegion}");

region ??= "Addis Ababa";
Console.WriteLine($"Region (assigned):{region}");


string studentName = "Abeba";
string studentId = "STU-001";
int enrollmentCount = 3;
decimal grantAmount = 1999.99m;
DateTime enrolledAt = DateTime.UtcNow;
string? campusRegion = null;

Console.WriteLine($"Student: {studentName} ({studentId})");
Console.WriteLine($"Courses: {enrollmentCount}");
Console.WriteLine($"Grant: {grantAmount:F2}");
Console.WriteLine($"Enrolled: {enrolledAt:yyyy-MM-dd}");
Console.WriteLine($"Campus: {campusRegion ?? "Not Assigned"}");



// EXERCISE 2
Console.WriteLine("\n--- EXERCISE 2: FINANCIAL PRECISION ---");
double legacygrantPerStudent = 1999.99;
double legacytotalAllocation = legacygrantPerStudent * 100_000;
Console.WriteLine($"Total allocated (double): {legacytotalAllocation}");
    
decimal grantPerStudent = 1999.99m;
decimal totalAllocation = grantPerStudent * 100_000m;
Console.WriteLine($"Total allocated (decimal): {totalAllocation}");
Console.WriteLine($"Total allocated (formatted): {totalAllocation:F2}");




// EXERCISE 3
Console.WriteLine("\n--- EXERCISE 3: Pipeline & Encapsulation Testing ---");


Console.WriteLine("--- Exercise 3 - Part 1: Record Immutability & Value Equality ---");

var enrollment = new EnrollmentRecord("STU-001", "CS-401", DateTime.UtcNow);
Console.WriteLine(enrollment);

var corrected = enrollment with { CourseCode = "CS-402"};
Console.WriteLine(corrected);

var duplicate = new EnrollmentRecord("STU-001", "CS-401", enrollment.EnrolledAt);
Console.WriteLine($"Same data? {enrollment == duplicate}");


// EXERCISE 3 Part 2
Console.WriteLine("\n--- Exercise 3 - Part 2: Course Capacity & Title Field Validation ---");

var course = new CourseCode {Code = "CS-401", Title = "Advanced C#", Capacity = 30};
Console.WriteLine($"Course: {course.Title} (Capacity: {course.Capacity})");

try
{
    course.Capacity = -5;
}
catch(ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}

try
{
    course.Title = "";
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}


// EXERCISE 3 Part 3
Console.WriteLine("\n--- Exercise 3 - Part 3: Student Property Range Rules ---");

var s = new Student {Id = "S1", Name="Abeba", Age=20, GPA=3.8m};
Console.WriteLine($"Student: {s.Name}, Age: {s.Age}, GPA: {s.GPA}");
