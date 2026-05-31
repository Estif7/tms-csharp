using System;
using System.Threading.Tasks;

namespace TmsCore;

public class EnrollmentService
{
    public EnrollmentRecord ProcessRegistration(Student? student, CourseCode? course)
    {
        // Precondition Guard Clauses
        if (student is null)
            throw new ArgumentNullException(nameof(student));
        
        if (course is null)
            throw new ArgumentNullException(nameof(course));

        // Module constraint: Check if enrollment count has met or exceeded course capacity
        if (course.EnrolledCount >= course.Capacity)
            throw new CapacityReachedException(course.Code);

        // Switch expression for Academic Standing classification
        string standing = student.GPA switch
        {
            >= 3.5m => "Honors",
            >= 2.5m => "Good Standing",
            _ => "Academic Warning"
        };

        Console.WriteLine($"  {student.Name} is in {standing}.");
        
        return new EnrollmentRecord(student.Id, course.Code, DateTime.UtcNow);
    }

    // Part B: Parallel Catalog Loading Engine
    public async Task LoadCourseCatalogParallelAsync(string[] courseCodes)
    {
        // Initialize an array of un-awaited task tracking references
        Task[] loadingTasks = new Task[courseCodes.Length];

        for (int i = 0; i < courseCodes.Length; i++)
        {
            string code = courseCodes[i];
            loadingTasks[i] = SimulateCatalogFetchAsync(code);
        }

        // Await all tasks concurrently; executes in parallel non-blockingly
        await Task.WhenAll(loadingTasks);
    }

    private async Task SimulateCatalogFetchAsync(string code)
    {
        await Task.Delay(150);
        Console.WriteLine($"[Catalog Engine] Loaded course configuration metadata for: {code}");
    }
}