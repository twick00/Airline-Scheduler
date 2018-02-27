using System;
using System.Collections.Generic;

namespace Airline_Planner.Models
{
    public class Flight
    {
        private bool _isDelayed;
        private City _destinationCity;
        private City _departureCity;
        private DateTime _arrivalTime;
        private DateTime _departureTime;
        private int _flightNumber;
        private Dictionary<int,List<char>> _availableSeats;
        private int _rowsInFlight;
        private char[] _seatsInRow = new char[] {'A','B','C','D'};//4 seats in a row. A & D are outside seats
        private List<Person> _passengerList;
        private List<Person> _staffList;
        private int _passengerCapacity;
        private int _passengerNumber;
        public Flight(City destinationCity, City departureCity, DateTime arrivalTime, DateTime departureTime, int flightNumber)
        {
            this._departureCity = destinationCity;
            this._departureCity = departureCity;
            this._arrivalTime = arrivalTime;
            this._departureTime = departureTime;
            this._flightNumber = flightNumber;
            this._isDelayed = false;
            //Below sets available rows in flight.
            for(int i = 0; i < _rowsInFlight; i++)
            {
                foreach(var seatInRow in _seatsInRow)
                {
                    if (_availableSeats.ContainsKey(i))
                    {
                        _availableSeats[i].Add(seatInRow);
                    }
                    else
                    {
                        _availableSeats[i] = new List<char> {seatInRow};
                    }
                }
            }
        }
        public void AddPassenger(Person newPerson)
        {
            this._passengerList.Add(newPerson);
        }
        public void RemovePassenger(Person removeThisPerson)
        {
            this._passengerList.Remove(removeThisPerson);
        }
        public void DelayFlight(DateTime newArrivalTime, DateTime newDepartureTime)
        {
            this._arrivalTime = newArrivalTime;
            this._departureTime = newDepartureTime;
            this._isDelayed = true;
            //Notify passengers(way too complicated to impliment)
        }
        
    }
}