using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Universe.Models;

namespace Universe.Services.ValidationService
{
    public class ValidationRegisterSpecification : IValidationRegisterSpecification
    {
        public bool IsSatisfiedBy(Rebelds registroRebelde)
        {
               
            var resultado = false;
            try
            {
                if (!string.IsNullOrEmpty(registroRebelde.Name) && !string.IsNullOrWhiteSpace(registroRebelde.Name)
                    && !string.IsNullOrEmpty(registroRebelde.Planet) && !string.IsNullOrWhiteSpace(registroRebelde.Planet))
                {
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                throw new ValidationException("No se han podido validar los rebeldes", ex);
            }
            return resultado;



        }
    }

}
//string cadena = valor.Name + valor.Planet;
//if (!string.IsNullOrWhiteSpace(cadena))
//{
//    return true;

//} else {
//    return false;}