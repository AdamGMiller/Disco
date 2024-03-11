using System.ComponentModel.DataAnnotations.Schema;

namespace Disco.Api.Entities
{
    [Table("tile")]
    public class Tile
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("tile_id")]
        public int TileId { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("uri")]
        public string Uri { get; set; }
    }
}
