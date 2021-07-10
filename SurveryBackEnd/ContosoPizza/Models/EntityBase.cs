using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models
{
    /// <summary>
    /// 基础实体类型
    /// </summary>
    public class EntityBase
    {
        // [Key]
        public int Id { get; set; }
        public bool IsActived { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        public int DisplayOrder { get; set; }
        public string Remark { get; set; } = "暂无备注";

    }
}