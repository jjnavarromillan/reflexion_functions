# reflexion_functions

# Pass a class to a different class on firts level and only on its equal fields

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
