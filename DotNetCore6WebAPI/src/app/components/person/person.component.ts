import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PersonService } from 'src/app/services/person.service';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.scss']
})
export class PersonComponent {
  personForm: FormGroup;

  constructor(private fb: FormBuilder, private personService: PersonService) {
    this.personForm = this.fb.group({
      name: ['', Validators.required],
      address: ['']
    });
  }

  onSubmit() {
    if (this.personForm && this.personForm.valid) {
      this.personService.addPerson(this.personForm.value)
        .subscribe(response => {
          this.personForm.reset();
          alert('Person added - '+ response.name + " " + response.id);
        });
    }
  }
}
