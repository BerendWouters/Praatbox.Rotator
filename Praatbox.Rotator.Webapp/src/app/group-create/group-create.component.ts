import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, RequiredValidator, Validators } from '@angular/forms';

@Component({
  selector: 'app-group-create',
  templateUrl: './group-create.component.html',
  styleUrls: ['./group-create.component.css']
})
export class GroupCreateComponent implements OnInit {
  groupNameFormControl: FormControl;
  amountOfMembersFormControl: FormControl;

  constructor() { 
    this.groupNameFormControl = new FormControl('', { validators: [Validators.required]})
    this.amountOfMembersFormControl = new FormControl(0, { validators: [Validators.required, Validators.min(2)]})
  }

  ngOnInit() {
   
  }

  onCreateGroup(){
    this.groupNameFormControl.markAsTouched();
    this.groupNameFormControl.updateValueAndValidity();
    this.amountOfMembersFormControl.markAsTouched();
    this.amountOfMembersFormControl.updateValueAndValidity();
  }

}
