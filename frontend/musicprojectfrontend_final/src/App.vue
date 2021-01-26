<template>
  <div class="bg">
    <router-view/>
  </div>
</template>



<style>
.bg{
  background: radial-gradient(ellipse at left,#707070, #303030);
}
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  background-color: radial-gradient(#808080, #404040);
  background-attachment: fixed;
  /* color: #2c3e50; */
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  /* color: #42b983; */
}
</style>
