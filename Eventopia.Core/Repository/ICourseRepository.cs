using Eventopia.Core.Data;

namespace Eventopia.Core.Repository;

public interface ICourseRepository
{
    List<Course>GetAllCourses();
}
