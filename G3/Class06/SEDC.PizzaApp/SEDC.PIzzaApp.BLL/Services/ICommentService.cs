using SEDC.PIzzaApp.BLL.DTOs.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.CommentApp.BLL.Services
{
    public interface ICommentService
    {
        public IEnumerable<CommentDTO> GetAll();

        public CommentDTO GetById(int id);

        public CommentDTO Update(CommentDTO CommentDTO);

        public CommentDTO Create(CommentDTO create);

        public void Delete(int id);
    }
}
