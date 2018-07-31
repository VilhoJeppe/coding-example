using Sample.BusinessLogicInterface.Dto;
using Sample.DatabaseEF.Objects;

namespace Sample.BusinessLogic
{
    public static class MovementMapper
    {
        public static CoordinateDto MapDto(this Coordinate domanObject) => new CoordinateDto
        {
            X = domanObject.X,
            Y = domanObject.Y,
            Z = domanObject.X
        };
    }
}
