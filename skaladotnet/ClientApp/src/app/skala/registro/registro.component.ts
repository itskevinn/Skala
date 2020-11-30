import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  Validators,
  AbstractControl,
} from '@angular/forms'
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { PersonaService } from 'src/app/services/persona.service';
import { Persona } from '../models/persona';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {
  persona: Persona
  formGroup: FormGroup
  constructor(private formBuilder: FormBuilder, public modal: NgbActiveModal, private personaService: PersonaService) { }
  ngOnInit(): void {
    this.persona = new Persona()
    this.formulario()
  }
  formulario() {
    this.persona.nombre = ''
    this.persona.email = ''
    this.formGroup = this.formBuilder.group({
      nombre: [this.persona.nombre, Validators.required],
      email: [this.persona.email, [Validators.required, Validators.email]]
    });
  }
  get control() {
    return this.formGroup.controls;
  }
  registrar() {
    this.persona = this.formGroup.value
    this.personaService.post(this.persona).subscribe((p) => {
      if (p != null) {
        this.persona = p
        this.formGroup.reset()
      }
    })
  }
}

