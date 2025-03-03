using ERP.Application.Abstractions.IServices;
using ERP.Application.Abstractions.IServices.IServices;
using ERP.Application.Abstractions.Services;
using ERP.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.Application;

public static class ERPDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAttendanceService, AttendanceService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IGradeService, GradeService>();
        services.AddScoped<IExamService, ExamService>();
        services.AddScoped<IFeePaymentService, FeePaymentService>();
        services.AddScoped<IParentService, ParentService>();
        services.AddScoped<IEnrollmentService, EnrollmentService>();
        services.AddScoped<IVideoService, VideoService>();

        return services;
    }
    
}