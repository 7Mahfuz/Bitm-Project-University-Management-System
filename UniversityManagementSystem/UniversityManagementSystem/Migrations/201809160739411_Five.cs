namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Five : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AllocateClassRooms", "IsAcTive", c => c.Boolean(nullable: false));
            AddColumn("dbo.CourseAssignTeachers", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.StudentEnrollInCourses", "IsAcTive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Teachers", "TeacherDesignation_Id", c => c.Int());
            AlterColumn("dbo.Courses", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Departments", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Results", "Grade", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "RegNo", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "ContactNo", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "ContactNo", c => c.String(nullable: false));
            CreateIndex("dbo.AllocateClassRooms", "DepartmentId");
            CreateIndex("dbo.AllocateClassRooms", "CourseId");
            CreateIndex("dbo.AllocateClassRooms", "RoomId");
            CreateIndex("dbo.AllocateClassRooms", "DayId");
            CreateIndex("dbo.Courses", "DepartmentId");
            CreateIndex("dbo.Courses", "SemesterId");
            CreateIndex("dbo.CourseAssignTeachers", "DepartmentId");
            CreateIndex("dbo.CourseAssignTeachers", "TeacherId");
            CreateIndex("dbo.Teachers", "DepartmentId");
            CreateIndex("dbo.Teachers", "TeacherDesignation_Id");
            CreateIndex("dbo.Results", "StudentId");
            CreateIndex("dbo.Results", "CourseId");
            CreateIndex("dbo.Students", "DepartmentId");
            CreateIndex("dbo.StudentEnrollInCourses", "StudentId");
            CreateIndex("dbo.StudentEnrollInCourses", "CourseId");
            AddForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters", "Id");
            AddForeignKey("dbo.AllocateClassRooms", "CourseId", "dbo.Courses", "Id");
            AddForeignKey("dbo.AllocateClassRooms", "DayId", "dbo.Days", "Id");
            AddForeignKey("dbo.AllocateClassRooms", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.AllocateClassRooms", "RoomId", "dbo.Rooms", "Id");
            AddForeignKey("dbo.CourseAssignTeachers", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.Teachers", "TeacherDesignation_Id", "dbo.TeacherDesignations", "Id");
            AddForeignKey("dbo.CourseAssignTeachers", "TeacherId", "dbo.Teachers", "Id");
            AddForeignKey("dbo.Results", "CourseId", "dbo.Courses", "Id");
            AddForeignKey("dbo.Students", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.Results", "StudentId", "dbo.Students", "Id");
            AddForeignKey("dbo.StudentEnrollInCourses", "CourseId", "dbo.Courses", "Id");
            AddForeignKey("dbo.StudentEnrollInCourses", "StudentId", "dbo.Students", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentEnrollInCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentEnrollInCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Results", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Results", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseAssignTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "TeacherDesignation_Id", "dbo.TeacherDesignations");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.CourseAssignTeachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AllocateClassRooms", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.AllocateClassRooms", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AllocateClassRooms", "DayId", "dbo.Days");
            DropForeignKey("dbo.AllocateClassRooms", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.StudentEnrollInCourses", new[] { "CourseId" });
            DropIndex("dbo.StudentEnrollInCourses", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.Results", new[] { "CourseId" });
            DropIndex("dbo.Results", new[] { "StudentId" });
            DropIndex("dbo.Teachers", new[] { "TeacherDesignation_Id" });
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.CourseAssignTeachers", new[] { "TeacherId" });
            DropIndex("dbo.CourseAssignTeachers", new[] { "DepartmentId" });
            DropIndex("dbo.Courses", new[] { "SemesterId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "DayId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "RoomId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "CourseId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "DepartmentId" });
            AlterColumn("dbo.Teachers", "ContactNo", c => c.String());
            AlterColumn("dbo.Teachers", "Name", c => c.String());
            AlterColumn("dbo.Students", "ContactNo", c => c.String());
            AlterColumn("dbo.Students", "RegNo", c => c.String());
            AlterColumn("dbo.Students", "Email", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String());
            AlterColumn("dbo.Results", "Grade", c => c.String());
            AlterColumn("dbo.Departments", "Name", c => c.String());
            AlterColumn("dbo.Departments", "Code", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
            AlterColumn("dbo.Courses", "Code", c => c.String());
            DropColumn("dbo.Teachers", "TeacherDesignation_Id");
            DropColumn("dbo.StudentEnrollInCourses", "IsAcTive");
            DropColumn("dbo.CourseAssignTeachers", "IsActive");
            DropColumn("dbo.AllocateClassRooms", "IsAcTive");
        }
    }
}
