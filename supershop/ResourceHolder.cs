
using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Resources;
using System.Collections;
using System.Xml;
using supershop;


namespace ResourceEditor
{
    //ResourceHolder is a component that holds the resources read out of a resources file
    //by implementing ICustomTypeDescriptor we make the shape of this component 
    //dynamic based on the contents resource file. This allows us to edit the 
    //resources in the PropertyGrid
    [TypeConverter((typeof(ExpandableObjectConverter)))]
    public class ResourceHolder : Component, ICustomTypeDescriptor
    {
        PropertyDescriptorCollection propsCollection;
        internal bool dirty = false;
        ResourceDescriptor desc;

        public ResourceDescriptor Current
        {
            get
            {
                return desc;
            }
            set
            {
                desc = value;
            }
        }

        public ResourceHolder()
            : base()
        {
            propsCollection = new PropertyDescriptorCollection(null);
        }

        public bool IsDirty
        {
            get { return dirty; }
            set { dirty = value; }
        }

        public ResourceHolder(IResourceReader rrdr)
            : this()
        {

            IDictionaryEnumerator resEnum = rrdr.GetEnumerator();
            while (resEnum.MoveNext())
            {

                string name = (string)resEnum.Key;
                object value = resEnum.Value;
                Console.WriteLine(name + " = " + value);

                ((IList)(propsCollection)).Add(new ResourceDescriptor(this, name, value));
            }
        }

        public void Clear()
        {
            propsCollection.Clear();
        }

        public void Add(string name, Type type)
        {
            if ((propsCollection[name] != null) | (CheckProperties(name) == true))
            {
                throw new ApplicationException("Invalid Resource Name");
            }
            ((IList)(propsCollection)).Add(new ResourceDescriptor(this, name, type));
            dirty = true;
        }

        public void Add(string name, Type type, string fileName, object value)
        {
            if ((propsCollection[name] != null) | (CheckProperties(name) == true))
            {
                throw new ApplicationException("Invalid Resource Name");
            }
            ((IList)(propsCollection)).Add(new ResourceDescriptor(this, name, type, fileName, value));
            dirty = true;
        }

        public void Rename(string name)
        {
            if ((propsCollection[name] != null) | (CheckProperties(name) == true))
            {
                throw new ApplicationException("Bad Name");
            }
            dirty = true;
        }

        public void Delete(PropertyDescriptor pd)
        {
            Console.WriteLine("removing " + ResCount);

            //IndexOf fails - why - check with sb
            Console.WriteLine("index is " + ((IList)(propsCollection)).IndexOf(pd));

            //Use brute force
            PropertyDescriptorCollection oldprops = propsCollection;
            propsCollection = new PropertyDescriptorCollection(null);

            IEnumerator pcEnum = oldprops.GetEnumerator();
            while (pcEnum.MoveNext())
            {
                object pCurrent = pcEnum.Current;
                if (pCurrent != pd)
                {
                    ((IList)(propsCollection)).Add(pcEnum.Current);
                }
            }

            Console.WriteLine("removed " + ResCount);
            dirty = true;
        }

        public void Rebuild()
        {
            PropertyDescriptorCollection oldprops = propsCollection;
            propsCollection = new PropertyDescriptorCollection(null);

            IEnumerator pcEnum = oldprops.GetEnumerator();
            while (pcEnum.MoveNext())
            {
                object pCurrent = pcEnum.Current;
                ((IList)(propsCollection)).Add(pcEnum.Current);
            }
            dirty = true;
        }

        public int ResCount
        {
            get
            {
                return ((IList)(propsCollection)).Count;
            }
        }

        public bool CheckProperties(string lookfor)
        {
            IEnumerator pcEnum = propsCollection.GetEnumerator();
            while (pcEnum.MoveNext())
            {
                ResourceDescriptor p = (ResourceDescriptor)(pcEnum.Current);
                if (p.ResourceName.ToLower() == lookfor.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public void DumpResources()
        {
            IEnumerator pcEnum = propsCollection.GetEnumerator();
            while (pcEnum.MoveNext())
            {
                ResourceDescriptor p = (ResourceDescriptor)(pcEnum.Current);
                if (null != p.ResourceValue)
                {
                    MessageBox.Show("Dumping " + p.ResourceName + " " + p.ResourceValue);
                }
            }
        }

        public void WriteResources(IResourceWriter rwtr)
        {
            try
            {
                IEnumerator pcEnum = propsCollection.GetEnumerator();
                while (pcEnum.MoveNext())
                {
                    ResourceDescriptor p = (ResourceDescriptor)(pcEnum.Current);
                    if (null != p.ResourceValue)
                    {
                        Console.WriteLine("Adding " + p.ResourceName + " " + p.ResourceValue + " " + p.Description);
                        rwtr.AddResource(p.ResourceName, p.ResourceValue);
                    }
                }
            }
            finally
            {
                //rwtr.Write();
                dirty = false;
            }
        }

        public void WriteXml(XmlTextWriter writer, string extension)
        {
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;

            writer.WriteStartDocument();
            writer.WriteStartElement("", "Resources", "");
            writer.WriteAttributeString("Extension", extension);

            IEnumerator pcEnum = propsCollection.GetEnumerator();
            foreach (ResourceDescriptor descriptor in propsCollection)
            {
                if (null != descriptor.ResourceValue)
                {
                    writer.WriteStartElement("", "Resource", "");
                    writer.WriteAttributeString("Name", descriptor.ResourceName);
                    writer.WriteAttributeString("Type", descriptor.PropertyType.ToString());
                    writer.WriteAttributeString("FileName", descriptor.FileName);
                    if (descriptor.PropertyType == typeof(string))
                        writer.WriteAttributeString("Value", descriptor.ResourceValue.ToString());
                    else
                        writer.WriteAttributeString("Value", "");

                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return new AttributeCollection(null);
        }

        string ICustomTypeDescriptor.GetClassName()
        {
            return null;
        }

        string ICustomTypeDescriptor.GetComponentName()
        {
            return null;
        }

        TypeConverter ICustomTypeDescriptor.GetConverter()
        {
            return null;
        }

        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        {
            return null;
        }


        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        {
            return null;
        }

        object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return null;
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return new EventDescriptorCollection(null);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            return new EventDescriptorCollection(null);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return propsCollection;
            //return((ICustomTypeDescriptor)this).GetProperties(null);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            return propsCollection;
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
    }
}
