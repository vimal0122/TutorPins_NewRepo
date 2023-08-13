﻿using AutoMapper;
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

        }
    }
}
