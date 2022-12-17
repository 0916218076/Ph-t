import React from "react";
//import React, {useEffect, useState} from "react";
//import { gapi } from "gapi-script";

import "./pageform.css"


const Pageform =() => {
  


    // const [popupStyle, showPopup] = useState("hide")

    // const popup = () => {
    //     showPopup("login-popup")
    //     setTimeout(() => showPopup("hide"), 3000)
    // }

    // const onSuccess = e => {
    //     alert("User signed in")
    //     console.log(e)
    // }

    // const onFailure = e => {
    //     alert("User sign in Failed")
    //     console.log(e)
    // }
   


return(
    <div class="login-div">
    <div class="logo"></div>
    <div class="title">Petrolimex</div>
    <div class="sub-title">beta</div>
    <div class="fields">
      <div class="username"><input type="username" class="user-input" placeholder=" enter your id" /></div>
      <div class="password"><input type="password" class="pass-input" placeholder=" enter your password" /></div>
    </div>
        <button class="signin-button">Login</button>
    <div class="link">
      <a href="#">Forgot password?</a> or <a href="#">Sign up</a>
    </div>
    {/* <div className={popupStyle}>
                <h3>Login Failed</h3>
                <p>Username or password incorrect</p>
            </div> */}
  </div>
)
}
export default Pageform