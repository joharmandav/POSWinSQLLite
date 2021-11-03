using System;
using System.Drawing;
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms;
using System.Resources;
using System.Collections;
using supershop;
using ResourceEditor;


namespace supershop
{
    /// <summary>
    /// Summary description for ReesourceDescriptor.
    /// </summary>
    public class ResourceDescriptor : PropertyDescriptor
    {
        static PickImageEditor editor;

        private ResourceHolder resourceHolder = null;
        private string name = null;
        private object value = null;
        private Type type = null;
        private string fileName = null;

        static ResourceDescriptor()
        {
            editor = new PickImageEditor();
        }
        public ResourceDescriptor(ResourceHolder resourceHolder, string name, object value)
            : this(resourceHolder, name, value.GetType())
        {
            this.value = value;
        }

        public ResourceDescriptor(ResourceHolder resourceHolder, string name, Type type, string fileName, object value)
            : this(resourceHolder, name, type)
        {
            this.fileName = fileName;

            if (value == null)
            {
                if (type == typeof(System.Drawing.Bitmap))
                    this.value = new Bitmap(fileName);
                else if (type == typeof(System.Drawing.Icon))
                    this.value = new Icon(fileName);
            }
            else
                this.value = value;
        }

        public ResourceDescriptor(ResourceHolder resourceHolder, string name, Type type)
            : base(name, null)
        {
            this.resourceHolder = resourceHolder;
            this.name = name;
            this.type = type;
        }


        public override string Category
        {
            get
            {
                return this.type.Name;
            }
        }

        public string ResourceName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        public object ResourceValue
        {
            get
            {
                return value;
            }
        }


        public override string DisplayName
        {
            get
            {
                if (fileName != null)
                    return (name + " [" + fileName + "]");
                else
                    return name;
            }
        }

        public override Type ComponentType
        {
            get
            {
                return typeof(ResourceHolder);
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public override Type PropertyType
        {
            get
            {
                return type;
            }
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override object GetValue(object component)
        {
            return value;
        }

        public override void ResetValue(object component)
        {
            resourceHolder.IsDirty = true;

            this.value = null;
        }

        public override void SetValue(object component, object value)
        {
            this.value = value;

            resourceHolder.IsDirty = true;
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }

        public override object GetEditor(Type editorBaseType)
        {
            if ((type == typeof(System.Drawing.Bitmap)) ||
                (type == typeof(System.Drawing.Icon)))
                return (editor);

            return base.GetEditor(editorBaseType);
        }
    }
}

