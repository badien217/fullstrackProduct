using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FeedbackDetail : EntityBase, IEntityBase
    {
        public UserProfiles Profile { get; set; }
        public int ProfileId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public string comment { get; set; }
        public FeedbackDetail() { }
        public FeedbackDetail(int  ProfileId, int ProductId,string comment)
        {
            this.comment = comment;
            this.ProductId = ProductId;
            this.ProfileId = ProfileId;
        }
    }
}
