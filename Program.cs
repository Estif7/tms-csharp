// EXERCISE 1
using TmsCore;

Console.WriteLine("\n ============================================================================");
Console.WriteLine(" EXERCISE 1: NULL HANDLING & STRING INTERPOLATION");
Console.WriteLine(" ============================================================================");

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
Console.WriteLine("\n ============================================================================");
Console.WriteLine(" EXERCISE 2: FINANCIAL PRECISION");
Console.WriteLine(" ============================================================================");

double legacygrantPerStudent = 1999.99;
double legacytotalAllocation = legacygrantPerStudent * 100_000;
Console.WriteLine($"Total allocated (double): {legacytotalAllocation}");
    
decimal grantPerStudent = 1999.99m;
decimal totalAllocation = grantPerStudent * 100_000m;
Console.WriteLine($"Total allocated (decimal): {totalAllocation}");
Console.WriteLine($"Total allocated (formatted): {totalAllocation:F2}");




// EXERCISE 3
Console.WriteLine("\n ============================================================================");
Console.WriteLine(" EXERCISE 3: Pipeline & Encapsulation Testing");
Console.WriteLine(" ============================================================================");

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



// EXERCISE 3B: POLYMORPHIC INTERFACE TESTING
Console.WriteLine("\n ============================================================================");
Console.WriteLine(" Exercise 3B: Polymorphic Grade Report");
Console.WriteLine(" ============================================================================");

// Create an array utilizing our IGradable interface contract
IGradable[] cohortAssessments = [
    new Quiz { Title = "C# Basics", CorrectAnswers = 18, TotalQuestions = 20 }, 
    new LabAssignment { Title = "Registration API", FunctionalityScore = 90m, CodeQualityScore = 85m }
];

// Call the polymorphic reporting engine
PrintGradeReport(cohortAssessments);

void PrintGradeReport(IEnumerable<IGradable> assessments)
{
    foreach (var item in assessments)
    {
        // We interact purely with the interface contract, completely decoupled from concrete classes
        Console.WriteLine($"{item.Title}: {item.CalculateGrade():F2}%");
    }
}



// EXERCISE 4: GUARD CLAUSES & PATTERN MATCHING VALIDATION
Console.WriteLine("\n ============================================================================");
Console.WriteLine(" EXERCISE 4: ENROLLMENT VALIDATION & GUARDS");
Console.WriteLine(" ============================================================================");

var service = new EnrollmentService();

// Test 1: Valid registration setup
var validStudent = new Student { Id = "S1", Name = "Abeba", Age = 20, GPA = 3.8m };
var validCourse = new CourseCode { Code = "CS-401", Title = "Advanced C#", Capacity = 30 };
var registrationResult = service.ProcessRegistration(validStudent, validCourse);
Console.WriteLine($"Enrolled: {registrationResult.StudentID} in {registrationResult.CourseCode}");

// Test 2: Null student guard trigger
try
{
    service.ProcessRegistration(null, validCourse);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"Guard caught: {ex.ParamName}");
}

// Test 3: Business rules exception verification (Full Course)
var fullCourse = new CourseCode { Code = "CS-402", Title = "Full Course", Capacity = 1 };
fullCourse.EnrolledCount = 1; // Manually mock full context
try
{
    service.ProcessRegistration(validStudent, fullCourse);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Business rule: {ex.Message}"); 
}


// EXERCISE 5: COLLECTIONS & LINQ PIPELINES
Console.WriteLine("\n ============================================================================");
Console.WriteLine(" EXERCISE 5: FACULTY ANALYTICS DASHBOARD");
Console.WriteLine(" ============================================================================");

// Step 1: Initialize list using C# 12+ Collection Expressions [cite: 405, 407]
List<Student> students = [
new Student { Id = "S1", Name = "Abeba", Age = 22, GPA = 3.8m },
new Student { Id = "S2", Name = "Kidane", Age = 21, GPA = 2.4m },
new Student { Id = "S3", Name = "Dawit", Age = 20, GPA = 3.1m },
new Student { Id = "S4", Name = "Sara", Age = 23, GPA = 3.9m },
new Student { Id = "S5", Name = "Frehiwot", Age = 19, GPA = 2.0m },
new Student { Id = "S6", Name = "Yonas", Age = 24, GPA = 3.5m },
new Student { Id = "S7", Name = "Meron", Age = 22, GPA = 1.8m },
new Student { Id = "S8", Name = "Tesfaye", Age = 21, GPA = 2.9m }
];

// Step 2: Build the Honors Leaderboard using chained LINQ extensions [cite: 410, 411]
List<string> leaderboard = students
.Where(s => s.GPA >= 3.5m)
.OrderByDescending(s => s.GPA)
.Select(s => s.Name)
.ToList();
    
Console.WriteLine($"Found {leaderboard.Count} Honors Students:");
foreach (var name in leaderboard)
{
Console.WriteLine($"- {name}");
}

// Step 3: Class Average [cite: 426]
decimal averageGpa = students.Average(s => s.GPA);
Console.WriteLine($"\nClass Average GPA: {averageGpa:F2}");

// Step 4: Group by Academic Standing using Switch Logic [cite: 432, 433]
var standingGroups = students.GroupBy(s => s.GPA switch
{
    >= 3.5m => "Honors", 
    >= 2.5m => "Good Standing", 
    >= 2.0m => "Probation",
_   => "Academic Warning"
});

Console.WriteLine("\n--- Academic Standing Report ---");
foreach (var group in standingGroups)
{
Console.WriteLine($"\n{group.Key} ({group.Count()}):");
foreach (var student in group)
    {
    Console.WriteLine($"  {student.Name} GPA: {student.GPA}");
    }
}

// Step 5: Collection Expressions with Spread Operator (..)
string[] backendCourses = ["C#", "ASP.NET Core"];
string[] frontendCourses = ["TypeScript", "Angular"];
string[] allCourses = [.. backendCourses, .. frontendCourses, "Capstone"]; 

Console.WriteLine($"\nFull curriculum: {string.Join(", ", allCourses)}");



