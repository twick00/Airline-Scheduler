using System;

namespace Airline_Planner.Models
{
    public class Person
    {
        private string _lastName;
        private string _firstName;
        private int _rowNum; //Ex: Row 13
        private char _seatChar; //Ex: Seat D

        public string LastName { get => _lastName; set => _lastName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public int RowNum { get => _rowNum; set => _rowNum = value; }
        public char SeatChar { get => _seatChar; set => _seatChar = value; }
    }
}