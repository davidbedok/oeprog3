using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WCFServiceLibraryDemo.Model
{
    [DataContract]
    public class Dimension
    {
        private int width;
        private int height;
        private int length;

        [DataMember]
        public int Width
        {
            get { return this.width; }
            internal set { this.width = value; }
        }

        [DataMember]
        public int Height
        {
            get { return this.height; }
            internal set { this.height = value; }
        }

        [DataMember]
        public int Length
        {
            get { return this.length; }
            internal set { this.length = value; }
        }

        public Dimension(int width, int height, int length)
        {
            this.width = width;
            this.height = height;
            this.length = length;
        }

        public override string ToString()
        {
            return String.Join(" ,", "[Dimension] ", "width=", this.width, "height=", this.height, "length=", this.length );
        }

    }
}
