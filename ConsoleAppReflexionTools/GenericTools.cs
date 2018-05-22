using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace ConsoleAppReflexionTools
{
    public static class GenericTools
    {

        
        public static T PassClassToClass<T>(T OrigenClass)
        {
            T DestinyClass = Activator.CreateInstance<T>();
            if (OrigenClass != null)
            {

                Type myTypeOrigen = OrigenClass.GetType();
                Type myTypeDestiny = DestinyClass.GetType();
                List<string> Fields = new List<string>();
                Fields = GetFields<T>(OrigenClass);

                foreach (string fieldName in Fields)
                {
                    PropertyInfo pinfoOrigen = myTypeOrigen.GetProperty(fieldName);
                    PropertyInfo pinfoDestiny = myTypeDestiny.GetProperty(fieldName);
                    pinfoDestiny.SetValue(DestinyClass, pinfoOrigen.GetValue(OrigenClass, null));
                }

            }
            return DestinyClass;


        }
        public static V PassClassToDifferentClass<T, V>(T OrigenClass)
        {
            V DestinyClass = Activator.CreateInstance<V>();
            if (OrigenClass != null)
            {

                Type myTypeOrigen = OrigenClass.GetType();
                Type myTypeDestiny = DestinyClass.GetType();
                List<string> FieldsOrigin = new List<string>();
                List<string> FieldsDestiny = new List<string>();
                FieldsOrigin = GetFields<T>(OrigenClass);
                FieldsDestiny = GetFields<V>(DestinyClass);

                foreach (string fieldName in FieldsOrigin)
                {
                    PropertyInfo pinfoOrigen = myTypeOrigen.GetProperty(fieldName);
                    PropertyInfo pinfoDestiny = myTypeDestiny.GetProperty(fieldName);
                    if (pinfoDestiny != null)
                    {
                        pinfoDestiny.SetValue(DestinyClass, pinfoOrigen.GetValue(OrigenClass, null));
                    }

                }

            }
            return DestinyClass;


        }
        public static List<String> GetFields<T>(T Object)
        {
            Type Type = Object.GetType();
            PropertyInfo[] pi = Type.GetProperties();
            List<string> fields = new List<string>();
            foreach (PropertyInfo p in pi)
            {
                if (!p.PropertyType.FullName.Contains("System.Collections.") && (p.PropertyType.FullName.Contains("System.String") || !p.PropertyType.BaseType.FullName.Contains("System.Object")))
                {
                    fields.Add(p.Name);
                }
            }
            return fields;
        }
        public static List<T> ListToList<T>(List<T> OrigenList)
        {
            List<T> DestinyList = new List<T>();

            foreach (T element in OrigenList)
            {
                T elementDest = Activator.CreateInstance<T>();
                elementDest = PassClassToClass<T>(element);
                DestinyList.Add(elementDest);
            }
            return DestinyList;

        }



        public static Task<List<T>> ListToListTask<T>(List<T> OrigenList)
        {
            List<T> DestinyList = new List<T>();

            Task<List<T>> task = Task.Run(() => ListToList(OrigenList));

            return task;

        }

    }
}
