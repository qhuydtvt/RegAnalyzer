using RegAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VM;

namespace RegAnalyzer.ViewModels
{
    public class CourseUrlListVM : BaseVM
    {
        public List<CourseUrl> CourseUrls
        {
            get
            {
                return CourseUrlList.Inst.List;
            }
        }

        public CourseUrl SelectedCourseUrl
        {
            get { return CourseUrlList.Inst.SelectedCourseUrl; }
            set { CourseUrlList.Inst.SelectedCourseUrl = value; }
        }
    }
}
