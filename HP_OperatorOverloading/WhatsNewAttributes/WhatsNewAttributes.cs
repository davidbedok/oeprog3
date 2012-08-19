using System;

namespace WhatsNewAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class LastModifiedAttribute: Attribute
    {
        private DateTime dateModified;
        public DateTime DateModified
        {
            get { return dateModified; }
        }

        private string changes;
        public string Changes
        {
            get { return changes; }
        }

        private string issues;
        public string Issues
        {
            get { return issues; }
            set { issues = value; }
        }

        public LastModifiedAttribute(string dateModified, string changes)
        {
            DateTime.TryParse(dateModified, out this.dateModified);
            this.changes = changes;
        }
    }

    [AttributeUsage(AttributeTargets.Assembly, Inherited=false)]
    public class SupportsWhatsNewAttribute: Attribute
    {
    }
}
