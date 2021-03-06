﻿namespace LibraryManagement.Data.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string FullName
        {
            get
            {
                return $"{Name} {Surname}";
            }
        }
        public bool Deleted { get; set; }
    }
}
