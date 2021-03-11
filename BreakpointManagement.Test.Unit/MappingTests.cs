using AutoMapper;
using BreakpointManagement.API;
using BreakpointManagement.Data.Models;
using BreakpointManagement.Shared.Models;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BreakpointManagement.Test.Unit
{
    public class MappingTests
    {
        private IMapper mapper { get; }
        private static Random random = new Random();
        public MappingTests()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BreakpointManagementProfile>();
            });
            configuration.AssertConfigurationIsValid();
            mapper = configuration.CreateMapper();
        }
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        [Theory]
        [InlineData(typeof(TblBreakpoint), typeof(Breakpoint))]
        [InlineData(typeof(TblBreakpointException), typeof(BreakpointException))]
        [InlineData(typeof(TblBreakpointgroup), typeof(Breakpointgroup))]
        [InlineData(typeof(TblBreakpointHistory), typeof(BreakpointHistory))]
        [InlineData(typeof(TblBreakpointInferred), typeof(BreakpointInferred))]
        [InlineData(typeof(TblBreakpointStandard), typeof(BreakpointStandard))]
        [InlineData(typeof(TblDrug), typeof(Drug))]
        [InlineData(typeof(TblDrugClass), typeof(DrugClass))]
        [InlineData(typeof(TblDrugSubclass), typeof(DrugSubclass))]
        [InlineData(typeof(TblOrganismFamily), typeof(OrganismFamily))]
        [InlineData(typeof(TblOrganismFamilyLanguage), typeof(OrganismFamilyLanguage))]
        [InlineData(typeof(TblOrganismGenus), typeof(OrganismGenus))]
        [InlineData(typeof(TblOrganismName), typeof(OrganismName))]
        [InlineData(typeof(TblOrganismNameLanguage), typeof(OrganismNameLanguage))]
        [InlineData(typeof(TblOrganismSubfamily), typeof(OrganismSubfamily))]
        [InlineData(typeof(TblOrganismSubfamilyLanguage), typeof(OrganismSubfamilyLanguage))]
        public void FieldsAreMapped(Type from, Type to)
        {
            var fromInstance = Activator.CreateInstance(from);

            var typePair = mapper.ConfigurationProvider.FindTypeMapFor(from, to);
            var fromType = typePair.SourceType;
            var toType = typePair.DestinationType;

            var fromProperties = fromType.GetProperties();
            foreach (var property in fromProperties)
            {
                if (property.PropertyType == typeof(string))
                {
                    property.SetValue(fromInstance, RandomString(10));
                }
                else if (property.PropertyType == typeof(int))
                {
                    property.SetValue(fromInstance, random.Next());
                }
                else if (property.PropertyType == typeof(DateTime?))
                {
                    property.SetValue(fromInstance, new DateTime(random.Next(1957, 2020), random.Next(1, 12), random.Next(1, 30)));
                }
                else if (property.PropertyType == typeof(bool?))
                {
                    property.SetValue(fromInstance, random.Next(0, 1) == 0 ? false : true);
                }
            }
            object toInstance = mapper.Map(fromInstance, fromType, toType);

            var toProperties = toType.GetProperties();
            foreach (var property in toProperties)
            {
                if(property.PropertyType == typeof(string) ||
                   property.PropertyType == typeof(int) ||
                   property.PropertyType == typeof(DateTime))
                {
                    var toValue = property.GetValue(toInstance);
                    //Assert.True(fromProperties.Any(p => p.GetValue(fromInstance) == toValue));
                    Assert.Contains(fromProperties, p => p.GetValue(fromInstance) != null && p.GetValue(fromInstance).Equals(toValue));
                }
            }
        }
    }
}
