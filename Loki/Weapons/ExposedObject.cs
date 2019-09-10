using System;
using System.Dynamic;
using System.Reflection;

namespace Loki.Weapons {
    //https://archive.codeplex.com/?p=exposedobject
    class ExposedObject : DynamicObject {
        readonly object _inst;
        readonly Type _type;

        internal ExposedObject(object inst, Type type = null) {
            _inst = inst;
            _type = type ?? _inst.GetType();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            result = null;
            var field = _type.GetField(binder.Name, (BindingFlags)(-1));
            if (field == null)
                return false;
            
            result = field.GetValue(_inst);
            
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value) {
            var field = _type.GetField(binder.Name, (BindingFlags)(-1));
            if (field == null)
                return false;
            
            field.SetValue(_inst, value);
            
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result) {
            result = null;

            var met = _type.GetMethod(binder.Name, (BindingFlags)(-1));
            if (met == null)
                return false;

            result = met.Invoke(_inst, args);
            return true;
        }
    }
}