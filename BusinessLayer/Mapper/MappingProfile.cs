using AutoMapper;
using BusinessLayer.Repository;
using BusinessLayer.Repository.IRepository;
using DataAccess.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseDto,Course>();
            CreateMap<Course, CourseDto>();

            CreateMap<CourseCategoryDto, CourseCategory>();
            CreateMap<CourseCategory, CourseCategoryDto>();

            CreateMap<CourseSubjectDto, CourseSubject>();
            CreateMap<CourseSubject, CourseSubjectDto>();

            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentDto>();

            CreateMap<TutorDto, Tutor>();
            CreateMap<Tutor, TutorDto>();

            CreateMap<TutorSubjectDto, TutorSubject>();
            CreateMap<TutorSubject, TutorSubjectDto>();

            CreateMap<LocationDto, Location>();
            CreateMap<Location, LocationDto>();

            CreateMap<OtherLocationDto, OtherLocation>();
            CreateMap<OtherLocation, OtherLocationDto>();

            CreateMap<TutorLocationDto, TutorLocation>();
            CreateMap<TutorLocation, TutorLocationDto>();

            CreateMap<QualificationDto, Qualification>();
            CreateMap<Qualification, QualificationDto>();

            CreateMap<TutorQualificationDto, TutorQualification>();
            CreateMap<TutorQualification, TutorQualificationDto>();

            CreateMap<StudentSubjectDto, StudentSubject>();
            CreateMap<StudentSubject, StudentSubjectDto>();

            CreateMap<StudentLocationDto, StudentLocation>();
            CreateMap<StudentLocation, StudentLocationDto>();

            CreateMap<TutorCategoryDto, TutorCategory>();
            CreateMap<TutorCategory, TutorCategoryDto>();

            CreateMap<spGetMatchedTutorDto, spGetMatchedTutor>();
            CreateMap<spGetMatchedTutor, spGetMatchedTutorDto>();

            CreateMap<spGetMatchedTutorDto, spGetMatchedTutorsByFilter>();
            CreateMap<spGetMatchedTutorsByFilter, spGetMatchedTutorDto>();

            CreateMap<MatchedTuitionDto, MatchedTuition>();
            CreateMap<MatchedTuition, MatchedTuitionDto>();

            CreateMap<MatchStatusValueDto, MatchStatusValue>();
            CreateMap<MatchStatusValue, MatchStatusValueDto>();

			CreateMap<spDashboardCountDto, spDashboardCount>();
			CreateMap<spDashboardCount, spDashboardCountDto>();

            CreateMap<spGetStudentRequestLogDto, spGetStudentRequestLog>();
            CreateMap<spGetStudentRequestLog, spGetStudentRequestLogDto>();

        }
    }
}
