using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _66bitFootball.Models
{
    public class Player 

    {
        public int Id { get; set; }
        [Display(Name = "имя")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Пол")]
        public Gender Gender { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Страна")]
        public Country Country { get; set; }

        [Display(Name = "Команда")]
        public int TeamId { get; set; }
        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; }
    }
    public enum Gender { Male, Female}
}
