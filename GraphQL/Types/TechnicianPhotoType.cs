using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using Warehouse.Models;
using Warehouse.Persistence;

namespace Warehouse.GraphQL.Types
{
    public class TechnicianPhotoType : ObjectType<TechnicianPhoto>
    {
        protected override void Configure(IObjectTypeDescriptor<TechnicianPhoto> descriptor)
        {
            descriptor
                .Description("Represents any photo that made of a technician");

            descriptor
                .Field(p => p.Id)
                .Description("Represents the unique identifier of a technician photo");

            descriptor
                .Field(p => p.FileName)
                .Description("Represents the file name of a photo");

            descriptor
                .Field(t => t.Technician)
                .ResolveWith<Resolver>(r => r.GetTechnician(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("Represents the technician who is on the photo");

            descriptor
                .Field(t => t.TechnicianId)
                .Description("Represents the unique identifier of a technician who is on the photo")
                .Ignore();
        }

        private class Resolver
        {
            public Technician GetTechnician(TechnicianPhoto photo, [ScopedService] ApplicationDbContext context)
            {
                return context.Technicians.SingleOrDefault(t => t.Id == photo.TechnicianId);
            }
        }
    }
}
