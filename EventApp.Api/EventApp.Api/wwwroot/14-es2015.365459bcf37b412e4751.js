(window.webpackJsonp=window.webpackJsonp||[]).push([[14],{"S+wf":function(e,t,a){"use strict";a.r(t),a.d(t,"RolesModule",(function(){return X}));var s=a("ofXK"),n=a("tyNb"),o=a("0IaG"),i=a("IOme"),c=a("fXoL"),r=a("Wp6s"),l=a("3Pt+"),d=a("bTqV"),b=a("NFeN"),m=a("bSwM");function u(e,t){if(1&e&&(c.Ub(0,"div",11),c.Ub(1,"mat-checkbox",12),c.fc("change",(function(){const e=t.$implicit;return e.checked=!e.checked})),c.Mc(2),c.Tb(),c.Tb()),2&e){const e=t.$implicit,a=c.jc();c.Bb(1),c.rc("value",e.name),c.qc("checked",e.checked)("disabled","Admin"===e.name&&"Admin"===a.user.userName),c.Bb(1),c.Nc(e.name)}}let p=(()=>{class e{constructor(e,t){this.dialogRef=e,this.data=t}ngOnInit(){this.dialogRef.addPanelClass("custom-dialog"),i.a.isDark()?this.dialogRef.addPanelClass("dark"):this.dialogRef.addPanelClass("light"),this.user=this.data.user,this.roles=this.data.roles}updateRoles(){this.dialogRef.close(this.roles)}}return e.\u0275fac=function(t){return new(t||e)(c.Ob(o.g),c.Ob(o.a))},e.\u0275cmp=c.Ib({type:e,selectors:[["app-roles-form"]],decls:24,vars:4,consts:[[1,"dialog-wrapper"],["mat-dialog-title",""],["mat-dialog-content",""],[1,"message"],["id","rolesForm"],["rolesForm","ngForm"],["class","form-check",4,"ngFor","ngForOf"],["mat-dialog-actions",""],[1,"spacer"],["mat-raised-button","","color","primary","cdkFocusInitial","",3,"mat-dialog-close"],["color","accent","mat-raised-button","",1,"mr-0",3,"click"],[1,"form-check"],[1,"example-margin",3,"value","checked","disabled","change"]],template:function(e,t){1&e&&(c.Ub(0,"div",0),c.Ub(1,"h1",1),c.Mc(2),c.Tb(),c.Ub(3,"mat-card"),c.Ub(4,"div",2),c.Ub(5,"p"),c.Mc(6,"Are you sure you want to Edit \u201c\xa0"),c.Ub(7,"span",3),c.Mc(8),c.Tb(),c.Mc(9,"\xa0\u201ds Roles?"),c.Tb(),c.Tb(),c.Ub(10,"div"),c.Ub(11,"form",4,5),c.Kc(13,u,3,4,"div",6),c.Tb(),c.Tb(),c.Ub(14,"div",7),c.Pb(15,"span",8),c.Ub(16,"button",9),c.Ub(17,"mat-icon"),c.Mc(18,"clear"),c.Tb(),c.Mc(19," No"),c.Tb(),c.Ub(20,"button",10),c.fc("click",(function(){return t.updateRoles()})),c.Ub(21,"mat-icon"),c.Mc(22,"edit"),c.Tb(),c.Mc(23," Yes"),c.Tb(),c.Tb(),c.Tb(),c.Tb()),2&e&&(c.Bb(2),c.Oc("Edit Roles for ",t.user.userName,""),c.Bb(6),c.Nc(t.user.userName),c.Bb(5),c.qc("ngForOf",t.roles),c.Bb(3),c.qc("mat-dialog-close",!1))},directives:[o.h,r.a,o.e,l.w,l.o,l.p,s.l,o.c,d.b,o.d,b.a,m.a],styles:[".message[_ngcontent-%COMP%]{font-weight:500}p[_ngcontent-%COMP%]{font-size:110%}div[mat-dialog-actions][_ngcontent-%COMP%]{margin-bottom:-10px}.dialog-wrapper[_ngcontent-%COMP%] > *[_ngcontent-%COMP%]{margin-left:-10px;margin-right:-10px}h1[_ngcontent-%COMP%]{margin-top:-24px;font-size:20px!important;margin-left:-24px!important;margin-right:-24px!important;padding:14px 14px 5px!important;border-bottom:1px solid rgba(0,0,0,.1)}"]}),e})();var h=a("tk/3"),f=a("AytR");let g=(()=>{class e{constructor(e){this.http=e,this.baseUrl=f.a.ApiUrl}getUsersWithRoles(e){let t=new h.d;return null!=e.name&&""!==e.name&&(t=t.set("name",e.name)),null!=e.roles&&""!==e.roles&&(t=t.set("roles",e.roles)),null!=e.id&&""!==e.id&&(t=t.set("id",e.id)),this.http.get(this.baseUrl+"admin/usersWithRoles",{observe:"response",params:t})}updateRoles(e,t){return this.http.post(`${this.baseUrl}admin/editRoles/${e.userName}`,t)}}return e.\u0275fac=function(t){return new(t||e)(c.cc(h.b))},e.\u0275prov=c.Kb({token:e,factory:e.\u0275fac,providedIn:"root"}),e})();var U=a("dNgK"),v=a("5VPf"),T=a("Xa2L"),w=a("kmnG"),R=a("qFsG"),M=a("+0xr"),k=a("M9IT"),y=a("yX84");function C(e,t){1&e&&(c.Ub(0,"div",3),c.Pb(1,"mat-spinner"),c.Ub(2,"h1",4),c.Mc(3,"Loading..."),c.Tb(),c.Tb())}function B(e,t){1&e&&(c.Ub(0,"th",26),c.Mc(1,"UserId"),c.Tb())}function D(e,t){if(1&e&&(c.Ub(0,"td",27),c.Mc(1),c.Tb()),2&e){const e=t.$implicit;c.Bb(1),c.Oc("UID",e.id,"")}}function S(e,t){1&e&&(c.Ub(0,"th",26),c.Mc(1,"UserName"),c.Tb())}function P(e,t){if(1&e&&(c.Ub(0,"td",27),c.Mc(1),c.kc(2,"titlecase"),c.Tb()),2&e){const e=t.$implicit;c.Bb(1),c.Oc(" ",c.lc(2,1,e.userName)," ")}}function F(e,t){1&e&&(c.Ub(0,"th",26),c.Mc(1,"Active Roles"),c.Tb())}function O(e,t){if(1&e&&(c.Ub(0,"td",27),c.Mc(1),c.Tb()),2&e){const e=t.$implicit;c.Bb(1),c.Oc(" ",e.roles," ")}}function I(e,t){1&e&&c.Pb(0,"th",28)}function x(e,t){if(1&e){const e=c.Vb();c.Ub(0,"button",31),c.fc("click",(function(){c.Bc(e);const t=c.jc().$implicit;return c.jc(2).editRoleModals(t)})),c.Ub(1,"mat-icon"),c.Mc(2,"edit"),c.Tb(),c.Mc(3," Change Roles "),c.Tb()}}const K=function(){return["Admin","Manager"]};function N(e,t){1&e&&(c.Ub(0,"td",29),c.Kc(1,x,4,0,"button",30),c.Tb()),2&e&&(c.Bb(1),c.qc("appHasRole",c.tc(1,K)))}function A(e,t){1&e&&c.Pb(0,"tr",32)}function q(e,t){1&e&&c.Pb(0,"tr",33)}const j=function(){return[5,10,25,50,100]};function z(e,t){if(1&e){const e=c.Vb();c.Ub(0,"div",5),c.Ub(1,"mat-card"),c.Ub(2,"mat-card-content"),c.Ub(3,"div",6),c.Ub(4,"div",7),c.Ub(5,"div",8),c.Ub(6,"mat-form-field",9),c.Ub(7,"mat-label"),c.Mc(8,"Filter by ID"),c.Tb(),c.Ub(9,"input",10),c.fc("keyup",(function(){return c.Bc(e),c.jc().loadData()})),c.Tb(),c.Tb(),c.Tb(),c.Pb(10,"span",11),c.Ub(11,"div",8),c.Ub(12,"mat-form-field",9),c.Ub(13,"mat-label"),c.Mc(14,"Filter by Name"),c.Tb(),c.Ub(15,"input",10),c.fc("keyup",(function(){return c.Bc(e),c.jc().loadData()})),c.Tb(),c.Tb(),c.Tb(),c.Tb(),c.Tb(),c.Ub(16,"div",12),c.Ub(17,"table",13),c.Sb(18,14),c.Kc(19,B,2,0,"th",15),c.Kc(20,D,2,1,"td",16),c.Rb(),c.Sb(21,17),c.Kc(22,S,2,0,"th",15),c.Kc(23,P,3,3,"td",16),c.Rb(),c.Sb(24,18),c.Kc(25,F,2,0,"th",15),c.Kc(26,O,2,1,"td",16),c.Rb(),c.Sb(27,19),c.Kc(28,I,1,0,"th",20),c.Kc(29,N,2,2,"td",21),c.Rb(),c.Kc(30,A,1,0,"tr",22),c.Kc(31,q,1,0,"tr",23),c.Tb(),c.Tb(),c.Ub(32,"div",24),c.Ub(33,"mat-paginator",25),c.fc("page",(function(t){return c.Bc(e),c.jc().paginate(t)})),c.Tb(),c.Tb(),c.Tb(),c.Tb(),c.Tb()}if(2&e){const e=c.jc();c.Bb(9),c.qc("formControl",e.codeField),c.Bb(6),c.qc("formControl",e.nameField),c.Bb(2),c.qc("dataSource",e.users),c.Bb(13),c.qc("matHeaderRowDef",e.displayedColumns),c.Bb(1),c.qc("matRowDefColumns",e.displayedColumns),c.Bb(2),c.qc("length",e.users.length)("pageSize",10)("pageSizeOptions",c.tc(9,j))("showFirstLastButtons",!0)}}const E=function(){return["Users","Show All Roles"]},L=[{path:"",component:(()=>{class e{constructor(e,t,a){this.roles=e,this.dialog=t,this.snackBar=a,this.displayedColumns=["userid","username","roles","update-col"],this.Roles=["Admin","Manager","Supervisor","Employee"],this.userParams={},this.pageSize=10,this.pageIndex=1,this.live=!1,this.codeField=new l.e,this.nameField=new l.e,this.roleField=new l.e}ngOnInit(){this.loadingState=!0,this.live=!0,this.loadData()}paginate(e){this.pagination.currentPage=e.pageIndex,this.pageSize=e.pageSize,this.pageIndex=e.pageIndex+1,this.loadData()}ngOnDestroy(){this.loadData(),this.live=!0,this.refreshData()}refreshData(){this.loadData()}loadData(){this.userParams.name=this.nameField.value,this.userParams.id=this.codeField.value,this.userParams.roles=this.roleField.value,this.roles.getUsersWithRoles(this.userParams).subscribe(e=>{this.loadingState=!1,this.users=e.body},e=>{switch(console.log(e),e.status){case 401:case 403:this.snackBar.open("Authorization Failed.","Access denied!",{duration:3e3}),setTimeout(()=>{},500);break;default:this.snackBar.open("there is a problem loading roles\u2757","\u274c",{duration:3e3})}})}editRoleModals(e){this.dialog.open(p,{width:"500px",data:{user:e,roles:this.getRolesArray(e)}}).afterClosed().subscribe(t=>{if(!t)return;this.loadingState=!0;const a={roleNames:[...t.filter(e=>!0===e.checked).map(e=>e.name)]};a&&this.roles.updateRoles(e,a).subscribe(()=>{e.roles=[...a.roleNames],this.snackBar.open("Roles Edited successfully","\u2714",{duration:2e3}),this.loadData()},e=>{console.log(e),this.snackBar.open("Failed to edit Roles\u2757 someting went wrong","\u274c",{duration:2e3}),this.loadingState=!1})})}getRolesArray(e){const t=[],a=e.roles,s=[{name:"Admin",value:"Admin"},{name:"Manager",value:"Manager"},{name:"Supervisor",value:"Supervisor"},{name:"Employee",value:"Employee"}];for(let n=0;n<s.length;n++){let e=!1;for(let o=0;o<a.length;o++)if(s[n].name===a[o]){e=!0,s[n].checked=!0,t.push(s[n]);break}e||(s[n].checked=!1,t.push(s[n]))}return t}}return e.\u0275fac=function(t){return new(t||e)(c.Ob(g),c.Ob(o.b),c.Ob(U.a))},e.\u0275cmp=c.Ib({type:e,selectors:[["app-roles-table"]],decls:4,vars:4,consts:[["title","Roles",3,"breadcrumbSegments"],["class","spinner",4,"ngIf","ngIfElse"],["userlist",""],[1,"spinner"],[1,"mat-h1","mt-3"],[1,"mat-elevation-z8"],[1,"mb-1"],[1,"row"],[1,"col-md-12","col-lg-6"],["appearance","outline",1,"w-100","search-form-field"],["matInput","",3,"formControl","keyup"],[1,"spacer"],[1,"table-responsive","table-striped"],["mat-table","",1,"w-100",3,"dataSource"],["matColumnDef","userid"],["mat-header-cell","",4,"matHeaderCellDef"],["mat-cell","",4,"matCellDef"],["matColumnDef","username"],["matColumnDef","roles"],["matColumnDef","update-col"],["class","btn-col","mat-header-cell","",4,"matHeaderCellDef"],["mat-cell","","class","btn-col",4,"matCellDef"],["mat-header-row","",4,"matHeaderRowDef"],["mat-row","",4,"matRowDef","matRowDefColumns"],[1,"mt-1"],[3,"length","pageSize","pageSizeOptions","showFirstLastButtons","page"],["mat-header-cell",""],["mat-cell",""],["mat-header-cell","",1,"btn-col"],["mat-cell","",1,"btn-col"],["class","mat-btn-sm","mat-raised-button","","color","accent",3,"click",4,"appHasRole"],["mat-raised-button","","color","accent",1,"mat-btn-sm",3,"click"],["mat-header-row",""],["mat-row",""]],template:function(e,t){if(1&e&&(c.Pb(0,"app-page-header",0),c.Kc(1,C,4,0,"div",1),c.Kc(2,z,34,10,"ng-template",null,2,c.Lc)),2&e){const e=c.yc(3);c.qc("breadcrumbSegments",c.tc(3,E)),c.Bb(1),c.qc("ngIf",t.loadingState)("ngIfElse",e)}},directives:[v.a,s.m,T.b,r.a,r.c,w.c,w.g,R.b,l.c,l.n,l.f,M.j,M.c,M.e,M.b,M.g,M.i,k.a,M.d,M.a,y.a,d.b,b.a,M.f,M.h],pipes:[s.v],styles:[".spinner[_ngcontent-%COMP%]{top:45%;left:47%;position:absolute}"]}),e})()},{path:"add",component:p}];let $=(()=>{class e{}return e.\u0275mod=c.Mb({type:e}),e.\u0275inj=c.Lb({factory:function(t){return new(t||e)},imports:[[n.g.forChild(L)],n.g]}),e})();var _=a("hctd"),H=a("FpXt");let X=(()=>{class e{}return e.\u0275mod=c.Mb({type:e}),e.\u0275inj=c.Lb({factory:function(t){return new(t||e)},imports:[[s.c,$,_.a,l.s,l.j,H.a]]}),e})()}}]);