import { Photos } from "./photos"

export interface Doctor {
  id: number
  name: string
  photoUrl: string
  speciality: string
  age: number
  gender: string
  country: string
  startDateTime: Date
  endDateTime: Date
  photos: Photos
}


