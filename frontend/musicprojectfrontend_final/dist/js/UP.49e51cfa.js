(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["UP"],{"0418":function(t,e,n){"use strict";var c=n("7a23");const o={class:"bg-headerGray h-16 flex justify-between"},r={class:"flex items-center"},a=Object(c["g"])("svg",{xmlns:"http://www.w3.org/2000/svg",width:"64",height:"64",viewBox:"0 0 86 86"},[Object(c["g"])("g",{id:"Group_4","data-name":"Group 4",transform:"translate(-2663 -2936)"},[Object(c["g"])("path",{id:"Path_1","data-name":"Path 1",d:"M0,0H86V86H0Z",transform:"translate(2663 2936)",fill:"#ffd163"}),Object(c["g"])("circle",{id:"Ellipse_1","data-name":"Ellipse 1",cx:"26.5",cy:"26.5",r:"26.5",transform:"translate(2679 2953)",fill:"#4d4d4d"}),Object(c["g"])("circle",{id:"Ellipse_2","data-name":"Ellipse 2",cx:"9.325",cy:"9.325",r:"9.325",transform:"translate(2696.675 2969.675)",fill:"#3f96f2"}),Object(c["g"])("circle",{id:"Ellipse_3","data-name":"Ellipse 3",cx:"2.072",cy:"2.072",r:"2.072",transform:"translate(2703.928 2976.928)",fill:"#ffc5d5"})])],-1),l=Object(c["f"])("self-made music"),s=Object(c["f"])("edited music"),i={class:"flex mx-8 items-center"},u={class:"bg-pinkLight mx-2 px-4 h-8 items-center flex cursor-pointer hover:opacity-70"},d=Object(c["f"])("Make new Song"),b={class:"bg-blue mx-2 px-4 h-8 items-center flex cursor-pointer hover:opacity-70"},f=Object(c["f"])("Upload New Song"),g={class:"bg-yellow mx-2 px-4 h-8 items-center flex cursor-pointer hover:opacity-70"},j=Object(c["f"])("logout");function p(t,e,n,p,O,h){const m=Object(c["u"])("router-link");return Object(c["p"])(),Object(c["d"])("div",o,[Object(c["g"])("div",r,[a,Object(c["g"])(m,{id:"SM",class:"mx-4 text-white changeBold hover:opacity-70",to:"/SM"},{default:Object(c["C"])(()=>[l]),_:1}),Object(c["g"])(m,{id:"UP",class:"mx-4 text-white changeBold hover:opacity-70",to:"/UP"},{default:Object(c["C"])(()=>[s]),_:1})]),Object(c["g"])("div",i,[Object(c["g"])("div",u,[Object(c["g"])(m,{to:"/NewSong"},{default:Object(c["C"])(()=>[d]),_:1})]),Object(c["g"])("div",b,[Object(c["g"])(m,{to:"/UploadSong"},{default:Object(c["C"])(()=>[f]),_:1})]),Object(c["g"])("div",g,[Object(c["g"])(m,{to:"/"},{default:Object(c["C"])(()=>[j]),_:1})])])])}var O=Object(c["h"])({props:{title:String},data:function(){return{SM:"",UP:""}},methods:{},mounted:function(){"SM"==this.title?document.getElementById("SM").classList.add("font-bold"):"UP"==this.title&&document.getElementById("UP").classList.add("font-bold"),console.log("done")}});O.render=p;e["a"]=O},"9ab4":function(t,e,n){"use strict";n.d(e,"a",(function(){return c})),n.d(e,"b",(function(){return o}));function c(t,e,n,c){function o(t){return t instanceof n?t:new n((function(e){e(t)}))}return new(n||(n=Promise))((function(n,r){function a(t){try{s(c.next(t))}catch(e){r(e)}}function l(t){try{s(c["throw"](t))}catch(e){r(e)}}function s(t){t.done?n(t.value):o(t.value).then(a,l)}s((c=c.apply(t,e||[])).next())}))}function o(t,e){var n,c,o,r,a={label:0,sent:function(){if(1&o[0])throw o[1];return o[1]},trys:[],ops:[]};return r={next:l(0),throw:l(1),return:l(2)},"function"===typeof Symbol&&(r[Symbol.iterator]=function(){return this}),r;function l(t){return function(e){return s([t,e])}}function s(r){if(n)throw new TypeError("Generator is already executing.");while(a)try{if(n=1,c&&(o=2&r[0]?c["return"]:r[0]?c["throw"]||((o=c["return"])&&o.call(c),0):c.next)&&!(o=o.call(c,r[1])).done)return o;switch(c=0,o&&(r=[2&r[0],o.value]),r[0]){case 0:case 1:o=r;break;case 4:return a.label++,{value:r[1],done:!1};case 5:a.label++,c=r[1],r=[0];continue;case 7:r=a.ops.pop(),a.trys.pop();continue;default:if(o=a.trys,!(o=o.length>0&&o[o.length-1])&&(6===r[0]||2===r[0])){a=0;continue}if(3===r[0]&&(!o||r[1]>o[0]&&r[1]<o[3])){a.label=r[1];break}if(6===r[0]&&a.label<o[1]){a.label=o[1],o=r;break}if(o&&a.label<o[2]){a.label=o[2],a.ops.push(r);break}o[2]&&a.ops.pop(),a.trys.pop();continue}r=e.call(t,a)}catch(l){r=[6,l],c=0}finally{n=o=0}if(5&r[0])throw r[1];return{value:r[0]?r[1]:void 0,done:!0}}}},de6c:function(t,e,n){"use strict";n.r(e);var c=n("7a23");const o={class:"h-screen"},r={class:"w-full flex flex-wrap justify-center mt-8 text-white"},a=Object(c["g"])("div",{class:"w-4/5 grid grid-cols-2 justify-start"},[Object(c["g"])("p",{class:"text-left font-bold border-b-2"},"Name"),Object(c["g"])("p",{class:"text-left font-bold border-b-2"},"Edit")],-1),l={class:"text-left mt-2"},s={class:"text-left mt-2"},i={class:"flex"},u=Object(c["f"])("Edit"),d=Object(c["g"])("p",null," |",-1),b=Object(c["f"])("Delete");function f(t,e,n,f,g,j){const p=Object(c["u"])("Header"),O=Object(c["u"])("router-link");return Object(c["p"])(),Object(c["d"])("div",o,[Object(c["g"])(p,{title:"UP"}),Object(c["g"])("div",r,[a,(Object(c["p"])(!0),Object(c["d"])(c["a"],null,Object(c["t"])(t.state.songs,e=>(Object(c["p"])(),Object(c["d"])("div",{class:"w-4/5 grid grid-cols-2 justify-start",key:e.userId},[Object(c["D"])(Object(c["g"])("p",l,"no songs found yet",512),[[c["A"],t.state.songs.length<=0]]),Object(c["g"])("p",s,Object(c["w"])(e.name),1),Object(c["g"])("div",i,[Object(c["g"])(O,{onClick:()=>t.editSong(e.name),class:"underline pr-2 hover:opacity-70",to:"/EditSong"},{default:Object(c["C"])(()=>[u]),_:2},1032,["onClick"]),d,Object(c["g"])(O,{key:e.userId,onClick:()=>t.deleteSong(e.name),class:"underline pl-2 text-pinkDark hover:opacity-70",to:"/UP"},{default:Object(c["C"])(()=>[b]),_:2},1032,["onClick"])])]))),128))])])}var g=n("9ab4"),j=n("bc3a"),p=n.n(j),O=n("0418"),h=Object(c["h"])({components:{Header:O["a"]},setup:function(){var t=Object(c["r"])({songs:[]});return{state:t}},data:function(){},methods:{deleteSong:function(t){return Object(g["a"])(this,void 0,void 0,(function(){var e;return Object(g["b"])(this,(function(n){switch(n.label){case 0:return[4,p.a.delete("Blob/"+localStorage.getItem("userId")+"/"+t)];case 1:return e=n.sent(),console.log(e),window.location.reload(),[2]}}))}))},editSong:function(t){console.log("whut"),localStorage.setItem("songName",t)}},created:function(){return Object(g["a"])(this,void 0,void 0,(function(){var t,e,n;return Object(g["b"])(this,(function(c){switch(c.label){case 0:return[4,p.a.get("Blob/AllSongs/"+localStorage.getItem("userId"))];case 1:return t=c.sent(),e=JSON.stringify(t.data),n=JSON.parse(e),this.state.songs=n,console.log(this.state.songs),[2]}}))}))}});h.render=f;e["default"]=h}}]);
//# sourceMappingURL=UP.49e51cfa.js.map