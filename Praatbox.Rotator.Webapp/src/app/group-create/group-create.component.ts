import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, RequiredValidator, Validators } from '@angular/forms';
import { CreateGroupResponseDTO, GroupProxy } from '../core/api.service';

@Component({
  selector: 'app-group-create',
  templateUrl: './group-create.component.html',
  styleUrls: ['./group-create.component.css']
})
export class GroupCreateComponent implements OnInit {
  groupNameFormControl: FormControl;
  amountOfMembersFormControl: FormControl;

  @Output() groupCreated = new EventEmitter<CreateGroupResponseDTO>();

  constructor(private groupProxy: GroupProxy) { 
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

    if(this.groupNameFormControl.valid && this.amountOfMembersFormControl.valid){
      this.groupProxy.createGroup(this.groupNameFormControl.value, this.amountOfMembersFormControl.value)
      .subscribe((res) => {
        this.groupCreated.emit(res);
      });
    }
  }

}
