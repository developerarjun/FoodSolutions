import { Component, OnInit } from '@angular/core';
import{FormGroup, FormBuilder, Validators} from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from '../_services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  loading = false;
  returnUrl: string;
  error = '';

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router:Router,
    private authenticationService: AuthenticationService
  ) { }

  ngOnInit(): void {


    // this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    //get return url from route parameter or default to '/'
    this.returnUrl = this.route.queryParams['returnUrl'] || '/';
     this.authenticationService.logout();

    if(localStorage.getItem('currentUser')){
      this.router.navigate([this.returnUrl]);
    }

    //binding from username and password
    this.loginForm = this.formBuilder.group({
      username: ['',Validators.required],
      password: ['',Validators.required]
    });

    
  }

  // get f() {return this.loginForm.controls;}
  
  onSubmit(){
    

    // stop here if form is invalid
    if(this.loginForm.invalid){
      return;
    }

    //button disabled once clicked
    this.loading = true;

    this.authenticationService.login(this.loginForm.value.username, this.loginForm.value.password)
      .subscribe(data =>{
        if(data){
          localStorage.setItem('currentUser', JSON.stringify(data));
        }

        this.router.navigate([this.returnUrl]);
      },
      error=>{
        this.error = error;

        //button removed from disabled
        this.loading = false;
      });

    
  }


}
