import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-ourservices',
  templateUrl: './ourservices.component.html',
  styleUrls: ['./ourservices.component.css']
})
export class OurservicesComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  services = [
    {
      'id': 1,
      'name': 'Dental Checkup',
      'description': 'Lorem Ipsum is simply dummy text of the printing and typesetting industry.',
      'image': '../../assets/dental-check-up.jpeg'
    },
    {
      'id': 2,
      'name': 'Dental Implants',
      'description': 'Lorem Ipsum is simply dummy text of the printing and typesetting industry.',
      'image': '../../assets/dental implants.jpg'
    },
    {
      'id': 3,
      'name': 'Dentures',
      'description': 'Lorem Ipsum is simply dummy text of the printing and typesetting industry.',
      'image': '../../assets/partial dentures.jpg'
    },
    {
      'id': 4,
      'name': 'Teeth Whitening',
      'description': 'Lorem Ipsum is simply dummy text of the printing and typesetting industry.',
      'image': '../../assets/dental whitening.jpg'
    }
  ]

}
