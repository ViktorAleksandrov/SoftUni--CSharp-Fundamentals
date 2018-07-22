using System;

namespace P08.CreateCustomClassAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomAttribute : Attribute
    {
        public CustomAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = reviewers;
        }

        public string Author { get; }

        public int Revision { get; }

        public string Description { get; }

        public string[] Reviewers { get; }
    }
}
