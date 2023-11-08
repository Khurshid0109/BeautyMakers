﻿using BeautyMakers.Domain.Enums;
using BeautyMakers.Domain.Commons;

namespace BeautyMakers.Domain.Entities;
public class BeautyProfessional:Auditable
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Gender Gender { get; set; }
    public string Description { get; set; }
    public string Experience { get; set; }
    public List<Appointment> Appointments { get; set; }
    public List<User> Users { get; set; }
    public List<PastWork> PastWorks { get; set; }
}
