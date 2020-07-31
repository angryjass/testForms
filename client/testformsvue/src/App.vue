<template>
  <div id="app">
    <router-link to="/" class="btn btn-secondary m-2" tag="button">Search</router-link>
    <router-link to="/submit" class="btn btn-secondary m-2" tag="button">Send</router-link>
    <router-view />
  </div>
</template>

<script>

export default {
  name: 'App'
}
</script>

<style>
</style>
