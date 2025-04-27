using System;

namespace Restaurants.Domain.Exceptions;

 public class NotFoundException(string resourceType,string resourceIdntifier) 
    : Exception($"{resourceType} with id :{resourceIdntifier} doesn't exist")
{
}
